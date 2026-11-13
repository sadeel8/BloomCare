namespace BloomCare.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }        // (اسم النبتة (مثل: صبرة، نعنوع
        public string UserId { get; set; }      // معرف المستخدم
    }
}
