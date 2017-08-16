using CMS_Golbarg.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Core.Models;

namespace CMS_Golbarg.Areas.Admin.Controllers
{

    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class DefaultController : Controller
    {
        // GET: Client/Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }
    }
}