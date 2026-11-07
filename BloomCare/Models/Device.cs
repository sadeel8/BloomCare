namespace BloomCare.Models
{
    public class Device
    {
        
            public int Id { get; set; }
            public string DeviceUniqueId { get; set; } // رقم التعريف الخاص بالجهاز (مثل ESP32_01)
            public string PlantName { get; set; }      // اسم النبتة التي اختارها المستخدم (مثل: البوتس، الصبار)
            public string UserId { get; set; }         // معرف المستخدم المالك للجهاز
        
    }
}
