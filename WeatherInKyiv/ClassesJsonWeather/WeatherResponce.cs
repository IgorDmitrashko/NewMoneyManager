using WeatherInKyiv.ClassesJsonWeather;

namespace WeatherInKyiv
{
   public struct WeatherResponce
   {
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }
    }
}
