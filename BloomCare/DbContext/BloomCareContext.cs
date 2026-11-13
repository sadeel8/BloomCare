using BloomCare.Models;
using BloomCareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BloomCareApi.Data
{
    public class BloomCareContext : DbContext
    {
        // دالة البناء يجب أن تحمل اسم الكلاس BloomCareContext فقط مرة واحدة
        public BloomCareContext(DbContextOptions<BloomCareContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
    }
}