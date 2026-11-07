using BloomCare.Models;
using BloomCareApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class DevicesController : ControllerBase
{
    private readonly BloomCareContext _context;

    public DevicesController(BloomCareContext context)
    {
        _context = context;
    }

    // ربط جهاز جديد أو تحديث اسم النبتة المرتبطة به
    [HttpPost("register")]
    public async Task<IActionResult> RegisterDevice([FromBody] Device deviceDto)
    {
        // التحقق إذا كان الجهاز مسجلاً مسبقاً
        var existingDevice = await _context.Devices
            .FirstOrDefaultAsync(d => d.DeviceUniqueId == deviceDto.DeviceUniqueId);

        if (existingDevice != null)
        {
            // إذا كان موجوداً، نقوم بتحديث اسم النبتة فقط
            existingDevice.PlantName = deviceDto.PlantName;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Device plant name updated successfully!", data = existingDevice });
        }

        // إذا لم يكن موجوداً، نقوم بإضافته جديداً لقاعدة البيانات
        _context.Devices.Add(deviceDto);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Device registered successfully!", data = deviceDto });
    }
}