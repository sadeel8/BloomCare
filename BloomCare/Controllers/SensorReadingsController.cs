using BloomCare.DTO;
using BloomCare.Models;
using BloomCare.Services;
using BloomCareApi.Data;
using BloomCare.DTOs; 
using BloomCareApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//نقطة الاستقبال الأساسية لقراءات الحساسات
namespace BloomCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorReadingsController : ControllerBase
    {
        private readonly BloomCareContext _context; 
        private readonly PlantRecommendationService _recommendationService;

        // حقن قاعدة البيانات وخدمة التوصيات داخل الـ Controller
        public SensorReadingsController(BloomCareContext context, PlantRecommendationService recommendationService)
        {
            _context = context;//قاعدة البيانات
            _recommendationService = recommendationService;// خدمة التوصيات الذكية
        }

        [HttpPost]//هذه الـ Endpoint تستقبل البيانات القادمة من الـ ESP32
        public async Task<IActionResult> AddReading([FromBody] CreateReadingDto dto)
        {
            // 1. البحث عن الجهاز ومعرفة النبتة المرتبط بها حالياً من الداتابيز (بناءً على الـ CurrentPlantId)
            var device = await _context.Devices
                .Include(d => d.CurrentPlant) // جلب بيانات النبتة المرتبطة مباشرة
                .FirstOrDefaultAsync(d => d.DeviceUniqueId == dto.DeviceUniqueId);

            if (device == null)
            {
                return BadRequest(new { message = "هذا الجهاز غير مسجل في النظام" });
            }

            if (device.CurrentPlantId == null || device.CurrentPlant == null)
            {
                return BadRequest(new { message = "الجهاز غير مربوط بأي نبتة حالياً. الرجاء تحديد النبتة أولاً." });
            }

            string plantName = device.CurrentPlant.Name;

            // 2. توليد التوصية الذكية بناءً على القراءات واسم النبتة الحالية
            string recommendation = _recommendationService.GetRecommendation(
                plantName,
                dto.SoilMoisture,
                dto.Temperature
            );

            // 3. إنشاء كائن القراءة وربطه بالـ PlantId الصحيح المستخرج من الداتابيز (منعاً للتلاعب أو التداخل)
            var reading = new SensorReading
            {
                DeviceUniqueId = dto.DeviceUniqueId,
                PlantId = device.CurrentPlantId.Value,
                Temperature = dto.Temperature,
                Humidity = dto.Humidity,
                SoilMoisture = dto.SoilMoisture,
                Timestamp = DateTime.UtcNow
            };

            // 4. حفظ قراءة الحساس في قاعدة البيانات
            _context.SensorReadings.Add(reading);
            await _context.SaveChangesAsync();

            // 5. إرجاع استجابة تحتوي على البيانات مع التوصية الذكية
            return Ok(new
            {
                message = "Reading saved successfully!",
                plant = plantName,
                plantId = device.CurrentPlantId.Value,
                recommendation = recommendation,
                data = reading
            });
        }
    }
}
