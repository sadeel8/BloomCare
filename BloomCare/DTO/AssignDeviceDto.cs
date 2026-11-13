namespace BloomCare.DTO
{
    public class AssignDeviceDto // لربط او نقل الجهاز بين النباتات
    {
        public string DeviceUniqueId { get; set; }
        public int NewPlantId { get; set; }
    }
}
