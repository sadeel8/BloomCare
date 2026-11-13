namespace BloomCare.DTO
{
    public class CreateReadingDto // لاستقبال قراءات الحساسات
    {
        public string DeviceUniqueId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float SoilMoisture { get; set; }
    }
}
