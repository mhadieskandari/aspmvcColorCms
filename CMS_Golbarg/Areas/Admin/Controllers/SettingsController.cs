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
    public class SettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Settings
        public async Task<ActionResult> Index()
        {
            Setting trans_fi=db.Settings.SingleOrDefault(m => m.Setting_Name == Setting.TRNSACTION_FI);
            if (trans_fi == null)
            {
                db.Settings.Add(new Setting { Setting_Name = Setting.TRNSACTION_FI });
                db.SaveChanges();
            }

            Setting showdaysNo = db.Settings.SingleOrDefault(m => m.Setting_Name == Setting.SHOWDAYS_NO);
            if (showdaysNo == null)
            {
                db.Settings.Add(new Setting { Setting_Name = Setting.SHOWDAYS_NO });
                db.SaveChanges();
            }


            return View(await db.Settings.ToListAsync());
        }

        //// GET: Settings/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Setting setting = await db.Settings.FindAsync(id);
        //    if (setting == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(setting);
        //}

        //// GET: Settings/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Settings/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "id,Setting_Name,Setting_Value")] Setting setting)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Settings.Add(setting);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(setting);
        //}

        // GET: Settings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = await db.Settings.FindAsync(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Setting_Name,Setting_Value")] Setting setting)
        {

            Setting old_setting = db.Settings.Find(setting.id);
            if (old_setting != null)
            {
                old_setting.Setting_Value = setting.Setting_Value;
            }

            if (ModelState.IsValid)
            {
                db.Entry(old_setting).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(old_setting);
        }

        //// GET: Settings/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Setting setting = await db.Settings.FindAsync(id);
        //    if (setting == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(setting);
        //}

        //// POST: Settings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Setting setting = await db.Settings.FindAsync(id);
        //    db.Settings.Remove(setting);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
