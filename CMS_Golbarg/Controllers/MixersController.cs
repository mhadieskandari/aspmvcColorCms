﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Models;
using CMS_Golbarg.ViewModel;
using AutoMapper;

namespace CMS_Golbarg.Controllers
{
    public class MixersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mixers
        public async Task<ActionResult> Index()
        {
            return View(await db.Mixers.Include(m=>m.ActualHairColor).Include(m => m.DestinationHairColor).ToListAsync());
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
            var Destination = db.HairColors.ToList();

            var viewModel = new CreateMixerViewModel
            {
                ActualHairColors = Actual,
                DestinationHairColors = Destination
            };

            return View(viewModel);
        }

        // POST: Mixers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Mix,DeColor,Oxidan,ActualHairColorID,DestinationHairColorID")] Mixer mixer)
        {
            if (ModelState.IsValid)
            {
                db.Mixers.Add(mixer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mixer);
        }

        // GET: Mixers/Edit/5
        public async Task<ActionResult> Edit(int? id)
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

        // POST: Mixers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Mix,DeColor,Oxidan")] Mixer mixer)
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
