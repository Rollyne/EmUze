using System.Diagnostics;
using System.Net;
using System.Web.Mvc;
using EmUzerWeb.Tools;
using EmUzerWeb.Tools.Weather;
using Newtonsoft.Json.Linq;
using WeatherNet.Clients;
using WeatherNet.Util.Api;

namespace EmUzerWeb.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetWeather(string latitude, string longtitude)
        {

            var url = "/weather?lat=" + latitude + "&lon=" + longtitude;
            var apiUrl = "http://api.openweathermap.org/data/2.5";
            var apiKey = "a1c52306b2406040f1763904d7f0163e";
            using (var client = new WebClient())
            {
                Trace.WriteLine("<HTTP - GET - " + url + " >");
                var response = client.DownloadString($"{apiUrl}{url}&appid={apiKey}");
                var parsedResponse = JObject.Parse(response);
                var item = WeatherDeserializer.GetWeatherCurrent(parsedResponse);
                
                return Json(item.Item.Title, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}