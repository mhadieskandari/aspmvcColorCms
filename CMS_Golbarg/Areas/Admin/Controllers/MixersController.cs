﻿using System;
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
using AutoMapper;
using CMS_Golbarg.Core.Models;

namespace CMS_Golbarg.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class MixersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mixers
        public async Task<ActionResult> Index(string ActualId, string DestinationId)
        {
            var model = db.Mixers.Include(m => m.ActualHairColor).Include(m => m.DestinationHairColor)
                .Include(m => m.PaintingWay);
            if (!string.IsNullOrEmpty(ActualId))
            {
                model = model.Where(m => m.ActualHairColor.InterNationalColorCode.Equals(ActualId));
            }
            if (!string.IsNullOrEmpty(DestinationId ))
            {
                model = model.Where(m => m.DestinationHairColor.InterNationalColorCode.Equals(DestinationId));
            }
            return View(await model.ToListAsync());
        }

        // GET: Mixers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mixer mixer = await db.Mixers.FindAsync(id);
            if (mixer == null)
            {
                return HttpNotFound();
            }
            return View(mixer);
        }

        // GET: Mixers/Create
        public ActionResult Create()
        {
            var Actual = db.HairColors.ToList();
            Actual = Actual.OrderBy(m => m.CodeDetail1).ThenBy(m => m.CodeBase1).ToList();
            var viewModel = new CreateMixerViewModel
            {
                ActualHairColors = Actual,
                DestinationHairColors = Actual,
                PaintingWays = db.PaintingWays.ToList()
            };

            return View(viewModel);
        }

        // POST: Mixers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "Id,Mix,DeColor,Oxidan,ActualHairColorID,DestinationHairColorID")] [Bind(Include = "Mixer.Mix,Mixer.DeColor,Mixer.Oxidan,Mixer.ActualHairColorID,Mixer.DestinationHairColorID")] 
        public async Task<ActionResult> Create(Mixer mixer)
        {
            if (ModelState.IsValid)
            {
                List<Mixer> test = db.Mixers.Where(m => m.ActualHairColorID == mixer.ActualHairColorID && m.DestinationHairColorID == mixer.DestinationHairColorID).ToList();
                if (test.Count == 0)
                {
                    db.Mixers.Add(mixer);
                    await db.SaveChangesAsync();
                    TempData["msg"] = "با موفقیت ثبت شد";
                    return RedirectToAction("Index");
                }
                else
                {
                    //ViewBag.msg = "این فرمول قبلا ثبت شده است";
                    TempData["msg"]="این فرمول قبلا ثبت شده است";
                    var Actual = db.HairColors.ToList();
                    Actual = Actual.OrderBy(m => m.CodeDetail1).ThenBy(m => m.CodeBase1).ToList();

                    CreateMixerViewModel a = new CreateMixerViewModel
                    {
                        Mixer = mixer,
                        ActualHairColors = Actual,
                        DestinationHairColors = Actual,
                        PaintingWays = db.PaintingWays.ToList()

                    };
                    



                    return View(a);
                }
                
            }
            return RedirectToAction("Create");

        }

        // GET: Mixers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mixer mixer = await db.Mixers.FindAsync(id);
            var Actual = db.HairColors.ToList();
            Actual = Actual.OrderBy(m => m.CodeDetail1).ThenBy(m => m.CodeBase1).ToList();
            CreateMixerViewModel mixerViewModel =new CreateMixerViewModel
            {
                Mixer = mixer,
                ActualHairColors = Actual,
                DestinationHairColors = Actual,
                PaintingWays = db.PaintingWays.ToList()
            };
            
            if (mixer == null)
            {
                return HttpNotFound();
            }
            return View(mixerViewModel);
        }

        // POST: Mixers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Mixer mixer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mixer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mixer);
        }

        // GET: Mixers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mixer mixer = await db.Mixers.FindAsync(id);
            if (mixer == null)
            {
                return HttpNotFound();
            }
            return View(mixer);
        }

        // POST: Mixers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mixer mixer = await db.Mixers.FindAsync(id);
            db.Mixers.Remove(mixer);
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
