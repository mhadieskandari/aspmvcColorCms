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

    [Authorize]
    public class BalancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Balances
        public ActionResult Index(string userid)
        {
             List<Balance> balances ;
            if (!string.IsNullOrEmpty(userid))
            {
                balances= db.Balances.Include(b => b.User).Where(m => m.UserID == userid).ToList();
            }
            else
            {
                balances = db.Balances.Include(b => b.User).ToList();
            }

            if (balances!=null)
            {
                return View(balances.ToList());
            }
            else
            {
                return HttpNotFound();
            }
            
            
        }

        public ActionResult IndexCreate(string userid)
        {
            List<Balance> balances;
            if (!string.IsNullOrEmpty(userid))
            {
                balances = db.Balances.Include(b => b.User).Where(m => m.UserID == userid).ToList();
                if (balances.Any())
                {
                    TempData["msg"] = "این مشتری دارای حساب فعال می باشد";
                    return RedirectToAction("index","Users");
                }
                else
                {
                    db.Balances.Add(new Balance() { BalanceNumber = userid, State = true,UserID=userid });
                    db.SaveChanges();
                    TempData["msg"] = "حساب با موفقیت ایجاد شد";
                    return RedirectToAction("index", "Users");
                }
            }
            else
            {
                return HttpNotFound();
            }

           


        }

        // GET: Balances/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balance balance = await db.Balances.FindAsync(id);
            if (balance == null)
            {
                return HttpNotFound();
            }
            return View(balance);
        }

        // GET: Balances/Create
        public ActionResult Create()
        {
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Balances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BalanceNumber,UserID,State")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                balance.UserID=User.Identity.GetUserId();
                db.Balances.Add(balance);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", balance.UserID);
            return View(balance);
        }

        // GET: Balances/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balance balance = await db.Balances.FindAsync(id);
            if (balance == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", balance.UserID);
            return View(balance);
        }

        // POST: Balances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BalanceNumber,UserID,State")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(balance).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", balance.UserID);
            return View(balance);
        }

        // GET: Balances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Balance balance = await db.Balances.FindAsync(id);
            if (balance == null)
            {
                return HttpNotFound();
            }
            return View(balance);
        }

        // POST: Balances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Balance balance = await db.Balances.FindAsync(id);
            db.Balances.Remove(balance);
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
