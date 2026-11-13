using BloomCare.Models;

namespace BloomCareApi.Models
{
    public class SensorReading //يخزن القيم القادمة من جهاز الـ ESP32
    {
        public int Id { get; set; }
        public float Temperature { get; set; }//حساس الحرارة
        public float Humidity { get; set; }//نسبة الرطوبة الجوية القادمة من الحساس
        public float SoilMoisture { get; set; }//نسبة رطوبة التربة
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;// وقت وصول القراءة بالتحديد

        public string DeviceUniqueId { get; set; } // الجهاز الذي أرسل القراءة
        public int PlantId { get; set; }            // النبتة التي كان يقيسها الجهاز وقت إرسال البيانات
        public Plant? Plant { get; set; }
    }
}