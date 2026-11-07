using BloomCare.Models;
using BloomCare.Services; 
using BloomCareApi.Data;
using BloomCareApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class SensorReadingsController : ControllerBase
{
    private readonly BloomCareContext _context;
    private readonly PlantRecommendationService _recommendationService;

    // حقن قاعدة البيانات وخدمة التوصيات داخل الـ Controller
    public SensorReadingsController(BloomCareContext context, PlantRecommendationService recommendationService)
    {
        _context = context;
        _recommendationService = recommendationService;
    }

    [HttpPost]
    public async Task<IActionResult> AddReading([FromBody] SensorReading reading)
    {
        // 1. البحث عن النبتة المرتبطة بهذا الجهاز في جدول الأجهزة
        var device = await _context.Devices
            .FirstOrDefaultAsync(d => d.DeviceUniqueId == reading.DeviceUniqueId);

        string plantName = device != null ? device.PlantName : "نبتة غير معروفة";

        // 2. توليد التوصية الذكية بناءً على القراءات واسم النبتة
        string recommendation = _recommendationService.GetRecommendation(
            plantName,
            reading.SoilMoisture,
            reading.Temperature
        );

        // 3. حفظ قراءة الحساس في قاعدة البيانات
        _context.SensorReadings.Add(reading);
        await _context.SaveChangesAsync();

        // 4. إرجاع استجابة تحتوي على البيانات مع التوصية الذكية
        return Ok(new
        {
            message = "Reading saved successfully!",
            plant = plantName,
            recommendation = recommendation,
            data = reading
        });
    }
}