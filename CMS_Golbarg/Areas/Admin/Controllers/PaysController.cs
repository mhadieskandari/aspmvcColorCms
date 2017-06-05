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
using Microsoft.AspNet.Identity;

namespace CMS_Golbarg.Areas.Admin.Controllers
{
    public class PaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pays
        public async Task<ActionResult> Index()
        {
            string userID = User.Identity.GetUserId();
            return View(await db.Pays.Include(m=>m.Balance).Where(m=>m.Balance.UserID==userID).ToListAsync());
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
            return View();
        }

        // POST: Pays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PayDate,ConfirmDate,PayAmount,State,TransitionOfBankNumber")] Pay pay)
        {
            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();
               Balance _bal = await db.Balances.SingleOrDefaultAsync(m => m.UserID ==userid );
                pay.BalanceID = _bal.Id;
                pay.InOutType = Pay.PayIn;
                db.Pays.Add(pay);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pay);
        }

        // GET: Pays/Edit/5
        public async Task<ActionResult> Edit(int? id)
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

        // POST: Pays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PayDate,ConfirmDate,PayAmount,State,TransitionOfBankNumber,InOutType")] Pay pay)
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
