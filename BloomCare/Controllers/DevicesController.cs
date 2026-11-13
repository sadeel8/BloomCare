using BloomCare.DTOs; 
using BloomCare.Models;
using BloomCareApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloomCare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {

      // [ المسؤول عن الاتصال بقاعدة البيانات وإجراء العمليات عليه [إضافة، تعديل، حذف، بحث
        private readonly BloomCareContext _context;

        public DevicesController(BloomCareContext context)
        {
            _context = context;
        }

        // نقل الجهاز لنبتة جديدة وتحديد مكان تواجده
        [HttpPost("switch-plant")]
        public async Task<IActionResult> SwitchPlant([FromBody] SwitchPlantDto dto)
        {
            // التاكد من وجود الجهاز 
            var device = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceUniqueId == dto.DeviceUniqueId);
            if (device == null)
                return NotFound("الجهاز غير موجود");
            // التاكد من وجود النبتة وحمايتها
            var plant = await _context.Plants.FirstOrDefaultAsync(p => p.Id == dto.PlantId && p.UserId == dto.UserId);
            if (plant == null)
                return NotFound("النبتة غير موجودة أو لا تتبع لهذا المستخدم");

            // تحديث النبتة الحالية للجهاز في الداتابيز
            device.CurrentPlantId = dto.PlantId;
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"تم نقل الجهاز بنجاح وأصبح يقرأ للنبتة: {plant.Name}" });
        }
    }
}