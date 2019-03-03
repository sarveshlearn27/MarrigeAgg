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
            //FillExcelDataDb();
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


        /// <summary>
        /// This is Temp Method
        /// </summary>
        private void FillExcelDataDb()
        {
            var matriMonyExcel = ControllerContext.HttpContext.Server.MapPath("~/AllMatrimonySites.xlsx");
            var profileExcel = ControllerContext.HttpContext.Server.MapPath("~/AllProfiles.xlsx");

            dbAdaptor = new Adaptor();
            dbAdaptor.FillAllWebSitesToDB(matriMonyExcel);
            dbAdaptor.FillAllProfilesToDB(profileExcel);
        }

    }
}