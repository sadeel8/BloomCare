namespace BloomCare.Services
{
    public class PlantRecommendationService
    {
        public string GetRecommendation(string plantName, double soilMoisture, double temperature)
        {
            if (soilMoisture < 30)
            {
                return $"تحذير: رطوبة التربة منخفضة جداً لنبتة ({plantName})! يرجى ري النبتة فوراً.";
            }
            else if (soilMoisture > 80)
            {
                return $"تنبيه: رطوبة التربة عالية جداً لنبتة ({plantName})، تجنب الري لتفادي تعفن الجذور.";
            }

            if (temperature > 35)
            {
                return $"تنبيه: درجة الحرارة مرتفعة حول نبتة ({plantName})، يفضل نقلها لمكان مظلل.";
            }

            return $"حالة نبتة ({plantName}) ممتازة! الظروف الحالية مثالية.";
        }
    }
}
