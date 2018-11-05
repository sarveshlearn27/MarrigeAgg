using MarrigeAggrigator.Core;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarrigerAggrigator.Controllers
{
    public class HomeController : Controller
    {
        IDBAdaptor dbAdaptor;
        public ActionResult Index()
        {
            var excelFilePath = ControllerContext.HttpContext.Server.MapPath("~/AllMatrimonySites.xlsx");
            dbAdaptor = new Adaptor();
            dbAdaptor.FillAllProfileDetailsToDb(excelFilePath);
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