using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Areas.Admin.Models;
using CMS_Golbarg.Core.Models;
using CMS_Golbarg.ViewModel;
using Microsoft.AspNet.Identity;

namespace CMS_Golbarg.Areas.Client.Controllers
{


    [Authorize(Roles = Roles.Customer + "," + Roles.Owner + "," + Roles.Administrator)]
    public class PaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pays
        public async Task<ActionResult> Index()
        {
            string userid = User.Identity.GetUserId();
            if (userid!=null)
            {
                var pays = await db.Pays.Include(m=>m.Balance.User).Include(m=>m.PayPlan).Where(m => m.Balance.UserID.Equals(userid)).ToListAsync();
                if (pays != null)
                {
                    return View(pays);
                }
                else
                {
                    return HttpNotFound();
                }

            }
            return View(await db.Pays.Include(m => m.Balance).Include(m => m.Balance.User).Include(m => m.PayPlan).ToListAsync());


        }

        // GET: Pays/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay pay = await db.Pays.FindAsync(id);
            if (pay == null)
            {
                return HttpNotFound();
            }
            return View(pay);
        }

        // GET: Pays/Create
        public ActionResult Create()
        {
            string userid = User.Identity.GetUserId();
            if (userid == null)
            {
                return HttpNotFound();
            }
            var model =new CreatePayViewModel
            {
                UserId = userid,
                UserName = User.Identity.Name,
                PayPlans = db.PayPlans.Where(m=>m.State==true).ToList()
            };
            return View(model);
        }

        // POST: Pays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePayViewModel payVM)
        {
            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();
                var pay=new Pay();
               Balance _bal = await db.Balances.SingleOrDefaultAsync(m => m.UserID == userid);
                if (_bal == null)
                {
                    TempData["msg"] = "شما حسابی ندارید ,لطفا با پشتیبانی تماس بگیرید.";
                    return RedirectToAction("Create");
                }
                pay.BalanceID = _bal.Id;
                pay.InOutType = Pay.PayIn;
                pay.PayPlanId = payVM.PayPlanId;
                pay.PayDate=DateTime.Now;
                var payPlan = db.PayPlans.Where(m => m.Id == payVM.PayPlanId).SingleOrDefault();

                if (payPlan == null)
                {
                    TempData["msg"] = "طرح مورد نظر یافت نشد";
                    return View();
                }

                pay.PayAmount = payPlan.PayAmount*payVM.Count;

                //pay.PayCoins=new List<PayCoin> {new PayCoin {InOutType = 1,NumberOfCoins = payPlan.NumberOfCoin,RegisterDate = DateTime.Now} };
                db.Pays.Add(pay);
                await db.SaveChangesAsync();

                db.PayCoins.Add(new PayCoin
                {
                    InOutType = 1,
                    NumberOfCoins = payPlan.NumberOfCoin * payVM.Count,
                    RegisterDate = DateTime.Now,
                    PayId = pay.Id
                });


                await db.SaveChangesAsync();



                return RedirectToAction("Index");
            }

            return View(payVM);
        }
               
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
