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
using System.IO;

namespace CMS_Golbarg.Areas.Admin.Controllers
{
    public class HairColorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HairColors
        public async Task<ActionResult> Index()
        {
            
            return View(await db.HairColors.OrderBy(m=>m.PersianColorCode).ToListAsync());
        }

        // GET: HairColors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairColor hairColor = await db.HairColors.FindAsync(id);
            if (hairColor == null)
            {
                return HttpNotFound();
            }
            return View(hairColor);
        }

        // GET: HairColors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HairColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,InterNationalColorCode,InterNationalColorName,PersianColorCode,PersianColorName,HairPic")] HairColor hairColor, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    hairColor.HairPic = ConvertToBytes(image);
                }


                db.HairColors.Add(hairColor);
                await db.SaveChangesAsync();
                //return RedirectToAction("Create");
                return RedirectToAction("Index");
            }

            return View(hairColor);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)

        {

            byte[] imageBytes = null;

            BinaryReader reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }

        // GET: HairColors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairColor hairColor = await db.HairColors.FindAsync(id);
            if (hairColor == null)
            {
                return HttpNotFound();
            }
            return View(hairColor);
        }

        // POST: HairColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for  [Bind(Include = "Id,InterNationalColorCode,InterNationalColorName,PersianColorCode,PersianColorName,HairPic")]
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,InterNationalColorCode,InterNationalColorName,PersianColorCode,PersianColorName,HairPic")] HairColor hairColor, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    hairColor.HairPic = ConvertToBytes(image);
                    db.Entry(hairColor).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    var oldHairColor = await db.HairColors.SingleOrDefaultAsync(m => m.Id == hairColor.Id);
                    //oldHairColor.HairPic = hairColor.HairPic;
                    oldHairColor.InterNationalColorCode = hairColor.InterNationalColorCode;
                    oldHairColor.InterNationalColorName = hairColor.InterNationalColorName;
                    oldHairColor.PersianColorCode = hairColor.PersianColorCode;
                    oldHairColor.PersianColorName = hairColor.PersianColorName;
                    db.Entry(oldHairColor).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                
               
            }
            return View(hairColor);
        }

        // GET: HairColors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairColor hairColor = await db.HairColors.FindAsync(id);
            if (hairColor == null)
            {
                return HttpNotFound();
            }
            return View(hairColor);
        }

        // POST: HairColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HairColor hairColor = await db.HairColors.FindAsync(id);
            try
            {
                db.HairColors.Remove(hairColor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.msg = "این رنگ مو در جداول دیگری استفاده شده و قابل حذف نمی باشد";
                string msg = e.Message.ToString();
                return View();
            }
           
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
