namespace BloomCare.Models
{
    public class Device
    {

        public int Id { get; set; }
        public string DeviceUniqueId { get; set; } // رقم القطعة الثابت (مثل ESP32_01)
        public string UserId { get; set; }         // معرف المستخدم الذي يمتلك الجهاز

        // النبتة التي يتواجد فيها الجهاز حالياً
        public int? CurrentPlantId { get; set; } //هذا الحقل عبارة عن "مؤشر" أو "رقم مكان الحفظ الحالي"
        public Plant? CurrentPlant { get; set; }//ملف النبة كامل
    }
}
