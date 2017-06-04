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
        [Authorize]
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
    }
}