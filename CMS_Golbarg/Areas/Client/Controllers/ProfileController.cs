using CMS_Golbarg.Areas.Admin.Models;
using CMS_Golbarg.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Golbarg.Areas.Client.Controllers
{
    public class ProfileController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Client/Profile
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var bal = db.Balances.Where(m => m.UserID == userId).SingleOrDefault();

            var profile = new ShowProfileViewModel()
            {
                User=db.Users.Find(userId),
                AccountBal=bal.GetPayBalance(),
                NumOfCoins=new UserInfo().GetCoins(userId)
            };

            return View(Profile);
        }
    }
}