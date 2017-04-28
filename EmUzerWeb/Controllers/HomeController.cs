using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Data.Data;
using Data.Models;
using EmUzerWeb.Tools;
using Microsoft.AspNet.Identity;

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
    }
}