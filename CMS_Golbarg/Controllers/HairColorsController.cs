using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Models;
using System.IO;

namespace CMS_Golbarg.Controllers
{
    public class HairColorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HairColors
        public async Task<ActionResult> Index()
        {
            
            return View(await db.HairColors.ToListAsync());
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
                    //Save image to file
                    //var filename = image.FileName;
                    //var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
                    //var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                    //string savedFileName = Path.Combine(filePathOriginal, filename);
                    //image.SaveAs(savedFileName);

                    hairColor.HairPic = ConvertToBytes(image);
                }


                db.HairColors.Add(hairColor);
                await db.SaveChangesAsync();
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,InterNationalColorCode,InterNationalColorName,PersianColorCode,PersianColorName,HairPic")] HairColor hairColor, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //Save image to file
                    //var filename = image.FileName;
                    //var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
                    //var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                    //string savedFileName = Path.Combine(filePathOriginal, filename);
                    //image.SaveAs(savedFileName);

                    hairColor.HairPic = ConvertToBytes(image);
                }


                db.Entry(hairColor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
            db.HairColors.Remove(hairColor);
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
