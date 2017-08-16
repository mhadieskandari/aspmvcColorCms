using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Areas.Admin.Models;
using CMS_Golbarg.Core.Models;
using Microsoft.AspNet.Identity;
using CMS_Golbarg.ViewModel;

namespace CMS_Golbarg.Areas.Client.Controllers
{


    [Authorize(Roles = Roles.Customer + "," + Roles.Owner)]
    public class DefaultController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Client/Default
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var bal = db.Balances.Where(m => m.UserID == userId).SingleOrDefault();
            if (bal != null)
            {
                var profile = new ShowProfileViewModel
                {
                    User = db.Users.Find(userId),
                    AccountBal = bal.GetPayBalance(),
                    NumOfCoins = new UserInfo().GetCoins(userId)
                };
                return View(profile);
            }
            else
            {
                TempData["msg"] = "حساب شما فعا نشده است و امکان ورود ندارید";
                return RedirectToAction("LogOff", "Account",new { Area="Admin"});
            }
        }
    }
}