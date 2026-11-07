namespace BloomCareApi.Models
{
    public class SensorReading
    {
        public int Id { get; set; }
        public string DeviceUniqueId { get; set; } 
        public double SoilMoisture { get; set; }
        public double Temperature { get; set; }
        public double LightLevel { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}