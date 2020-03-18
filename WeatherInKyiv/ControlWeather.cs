using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace WeatherInKyiv
{
    public class ControlWeather
    {
        public string GetWeather(string url = "http://api.openweathermap.org/data/2.5/weather?q=Kyiv&appid=883ce8e32c9731721a8c6aeaaee11eb4") {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                string response;
                using(var stream = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = stream.ReadToEnd();
                }
                WeatherResponce jsonweatherResponce = JsonConvert.DeserializeObject<WeatherResponce>(response);

                jsonweatherResponce.Main.Temp = (int)(jsonweatherResponce.Main.Temp - 273.15);
                return $"{jsonweatherResponce.Name}\n     {jsonweatherResponce.Main.Temp} C°";
            }

            catch(Exception)
            {
                return "Ошибка";
            }
        }
    }
}