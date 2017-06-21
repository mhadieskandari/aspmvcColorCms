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
    public class PayPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PayPlans
        public async Task<ActionResult> Index()
        {
            return View(await db.PayPlans.ToListAsync());
        }

        // GET: Admin/PayPlans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPlan payPlan = await db.PayPlans.FindAsync(id);
            if (payPlan == null)
            {
                return HttpNotFound();
            }
            return View(payPlan);
        }

        // GET: Admin/PayPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PayPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PlanName,PlanDes,Fi,NumberOfCoin,StartDate,EndDate")] PayPlan payPlan)
        {
            if (ModelState.IsValid)
            {
                db.PayPlans.Add(payPlan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(payPlan);
        }

        // GET: Admin/PayPlans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPlan payPlan = await db.PayPlans.FindAsync(id);
            if (payPlan == null)
            {
                return HttpNotFound();
            }
            return View(payPlan);
        }

        // POST: Admin/PayPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PlanName,PlanDes,Fi,NumberOfCoin,StartDate,EndDate")] PayPlan payPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payPlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(payPlan);
        }

        // GET: Admin/PayPlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayPlan payPlan = await db.PayPlans.FindAsync(id);
            if (payPlan == null)
            {
                return HttpNotFound();
            }
            return View(payPlan);
        }

        // POST: Admin/PayPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PayPlan payPlan = await db.PayPlans.FindAsync(id);
            db.PayPlans.Remove(payPlan);
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
