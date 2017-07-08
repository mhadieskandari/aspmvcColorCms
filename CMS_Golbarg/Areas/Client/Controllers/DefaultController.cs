using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Areas.Admin.Models;

namespace CMS_Golbarg.Areas.Client.Controllers
{


    [Authorize(Roles = Roles.Customer + "," + Roles.Owner)]
    public class DefaultController : Controller
    {
        // GET: Client/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}