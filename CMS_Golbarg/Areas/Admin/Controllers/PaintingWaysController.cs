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
    public class PaintingWaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PaintingWays
        public async Task<ActionResult> Index()
        {
            return View(await db.PaintingWays.ToListAsync());
        }

        // GET: Admin/PaintingWays/Details/5
        public async Task<ActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaintingWay paintingWay = await db.PaintingWays.FindAsync(id);
            if (paintingWay == null)
            {
                return HttpNotFound();
            }
            return View(paintingWay);
        }

        // GET: Admin/PaintingWays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PaintingWays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Description,Content")] PaintingWay paintingWay)
        {
            if (ModelState.IsValid)
            {
                db.PaintingWays.Add(paintingWay);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paintingWay);
        }

        // GET: Admin/PaintingWays/Edit/5
        public async Task<ActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaintingWay paintingWay = await db.PaintingWays.FindAsync(id);
            if (paintingWay == null)
            {
                return HttpNotFound();
            }
            return View(paintingWay);
        }

        // POST: Admin/PaintingWays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Content")] PaintingWay paintingWay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paintingWay).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paintingWay);
        }

        // GET: Admin/PaintingWays/Delete/5
        public async Task<ActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaintingWay paintingWay = await db.PaintingWays.FindAsync(id);
            if (paintingWay == null)
            {
                return HttpNotFound();
            }
            return View(paintingWay);
        }

        // POST: Admin/PaintingWays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(byte id)
        {
            PaintingWay paintingWay = await db.PaintingWays.FindAsync(id);
            db.PaintingWays.Remove(paintingWay);
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
