using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmUzerWeb.Tools;
using System.Threading.Tasks;

namespace EmUzerWeb.Controllers
{
    public class EmotionController : Controller
    {
        // GET: Emotion
        [HttpPost]
        public JsonResult Post(string imageString)
        {
            //string filename = Server.MapPath("~/Images/" + Guid.NewGuid() + ".png");
            //System.IO.File.WriteAllBytes(filename, Convert.FromBase64String(imageString.Replace("data:image/png;base64,", string.Empty)));

            //EmotionClassifier classifier = new EmotionClassifier();
            //string emotion = Task.Run(() => classifier.Classify(filename)).Result;
            //System.IO.File.Delete(filename);
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }
}