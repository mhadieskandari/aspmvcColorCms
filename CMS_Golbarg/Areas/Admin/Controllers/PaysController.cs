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
using CMS_Golbarg.ViewModel;
using Microsoft.AspNet.Identity;

namespace CMS_Golbarg.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class PaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pays
        public async Task<ActionResult> Index(string userid)
        {
            if (userid!=null)
            {
                var pays = await db.Pays.Include(m => m.Balance).Include(m=>m.Balance.User).Include(m=>m.PayPlan).Where(m => m.Balance.UserID.Equals(userid)).ToListAsync();
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
        public ActionResult Create(string userid)
        {
            if (userid == null)
            {
                return HttpNotFound();
            }
            var model =new CreatePayViewModel
            {
                UserId = userid,
                UserName = db.Users.Where(m=>m.Id==userid).SingleOrDefault().UserName,
                PayPlans = db.PayPlans.Where(m=>m.State==true).ToList()
            };
            return View(model);
        }

        // POST: Pays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePayViewModel payVM)
        {
            if (ModelState.IsValid)
            {
               var pay=new Pay();
               Balance _bal =db.Balances.SingleOrDefault(m => m.UserID == payVM.UserId );
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
                db.SaveChanges();

                db.PayCoins.Add(new PayCoin
                {
                    UserID = _bal.UserID,
                    InOutType = 1,
                    NumberOfCoins = payPlan.NumberOfCoin * payVM.Count,
                    RegisterDate = DateTime.Now,
                    PayId = pay.Id
                });


                db.SaveChanges();



                return RedirectToAction("Index","Users");
            }

            return View(payVM);
        }

        // GET: Pays/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pays = await db.Pays.Include(m=>m.PayPlan).Include(m=>m.Balance).Include(m=>m.Balance.User).ToListAsync();
            var pay = pays.Where(m=>m.Id==id).SingleOrDefault();
            if (pay == null)
            {
                return HttpNotFound();
            }
            return View(pay);
        }

        // POST: Pays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(/*[Bind(Include = "Id,ConfirmDate,State,TransitionOfBankNumber")]*/ Pay pay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pay).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pay);
        }

        // GET: Pays/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: Pays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pay pay = await db.Pays.FindAsync(id);
            db.Pays.Remove(pay);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
