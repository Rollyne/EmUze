using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace EmUzerWeb.Tools.Weather
{
    public class WeatherDeserializer
    {
        public static SingleResult<WeatherCurrent> GetWeatherCurrent(JObject response)
        {
            //var error = GetServerErrorFromResponse(response);
            //if (!String.IsNullOrEmpty(error))
            //    return new SingleResult<WeatherCurrent>(null, false, error);

            var weatherCurrent = new WeatherCurrent();

            if (response["sys"] != null)
            {
                weatherCurrent.Country = Encoding.UTF8.GetString(Encoding.Default.GetBytes(Convert.ToString(response["sys"]["country"])));
            }

            if (response["weather"] != null)
            {
                weatherCurrent.Title = Encoding.UTF8.GetString(Encoding.Default.GetBytes(Convert.ToString(response["weather"][0]["main"])));
                weatherCurrent.Description = Encoding.UTF8.GetString(Encoding.Default.GetBytes(Convert.ToString(response["weather"][0]["description"])));
                weatherCurrent.Icon = Encoding.UTF8.GetString(Encoding.Default.GetBytes(Convert.ToString(response["weather"][0]["icon"])));
                weatherCurrent.ConditionID = Convert.ToInt32(response["weather"][0]["id"]);
            }

            if (response["main"] != null)
            {
                weatherCurrent.Temp = Convert.ToDouble(response["main"]["temp"]);
                weatherCurrent.TempMax = Convert.ToDouble(response["main"]["temp_max"]);
                weatherCurrent.TempMin = Convert.ToDouble(response["main"]["temp_min"]);
                weatherCurrent.Humidity = Convert.ToDouble(response["main"]["humidity"]);
            }

            if (response["wind"] != null)
            {
                weatherCurrent.WindSpeed = Convert.ToDouble(response["wind"]["speed"]);
            }

            weatherCurrent.Date = DateTime.UtcNow;
            weatherCurrent.City = Encoding.UTF8.GetString(Encoding.Default.GetBytes(Convert.ToString(response["name"])));
            weatherCurrent.CityId = Convert.ToInt32(response["id"]);

            return new SingleResult<WeatherCurrent>(weatherCurrent, true, "Success");
        }
    }
}