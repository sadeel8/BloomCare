using System.Collections.Generic;
using BloomCare.Models;
using BloomCareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BloomCareApi.Data
{
    public class BloomCareContext : DbContext
    {
        public BloomCareContext(DbContextOptions<BloomCareContext> options) : base(options) { }

        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
