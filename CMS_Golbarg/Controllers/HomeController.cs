using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Golbarg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "صفحه اصلی";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "درباره ما";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "ارتباط با ما";

            return View();
        }

        public ActionResult GoldAccount()
        {
            ViewBag.Title = "کاربر طلایی";

            return View();
        }

        public ActionResult SilverAccount()
        {
            ViewBag.Title = "کاربر نقره ای";

            return View();
        }

        public ActionResult BoronseAccount()
        {
            ViewBag.Title = "کاربر برنزی";

            return View();
        }


    }
}