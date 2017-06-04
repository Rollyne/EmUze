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
    }
}