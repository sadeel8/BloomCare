namespace BloomCare.DTOs
{
    public class SwitchPlantDto
    {
        public string?DeviceUniqueId { get; set; } // رقم الجهاز المراد نقله
        public int PlantId { get; set; }        // رقم النبتة الجديدة
        public string? UserId { get; set; }         // صاحب النبتة (للحماية)
    }
}

