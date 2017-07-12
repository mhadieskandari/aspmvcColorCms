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

namespace CMS_Golbarg.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class PayCoinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PayCoins
        public async Task<ActionResult> Index(string userId)
        {
            if (userId != null)
            {
                var payCoins = db.PayCoins.Include(p => p.Pay.PayPlan).Include(m=>m.Pay.Balance.User).Where(m=>m.Pay.Balance.User.Id==userId);
                return View(await payCoins.ToListAsync());
            }
            else
            {
                var payCoins = db.PayCoins.Include(p => p.Pay.PayPlan).Include(m => m.Pay.Balance.User);
            return View(await payCoins.ToListAsync());
            }
            
        }

        // GET: Admin/PayCoins/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayCoin payCoin = await db.PayCoins.FindAsync(id);
            if (payCoin == null)
            {
                return HttpNotFound();
            }
            return View(payCoin);
        }

        // GET: Admin/PayCoins/Create
        public ActionResult Create()
        {
            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber");
            return View();
        }

        // POST: Admin/PayCoins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PayId,NumberOfCoins,InOutType,RegisterDate")] PayCoin payCoin)
        {
            if (ModelState.IsValid)
            {
                db.PayCoins.Add(payCoin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber", payCoin.PayId);
            return View(payCoin);
        }

        // GET: Admin/PayCoins/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayCoin payCoin = await db.PayCoins.FindAsync(id);
            if (payCoin == null)
            {
                return HttpNotFound();
            }
            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber", payCoin.PayId);
            return View(payCoin);
        }

        // POST: Admin/PayCoins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PayId,NumberOfCoins,InOutType,RegisterDate")] PayCoin payCoin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payCoin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber", payCoin.PayId);
            return View(payCoin);
        }

        // GET: Admin/PayCoins/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayCoin payCoin = await db.PayCoins.FindAsync(id);
            if (payCoin == null)
            {
                return HttpNotFound();
            }
            return View(payCoin);
        }

        // POST: Admin/PayCoins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PayCoin payCoin = await db.PayCoins.FindAsync(id);
            db.PayCoins.Remove(payCoin);
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
