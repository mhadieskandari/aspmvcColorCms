﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CMS_Golbarg.Areas.Admin.Models;
using CMS_Golbarg.ViewModel;
using AutoMapper;
using CMS_Golbarg.Core.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;

namespace CMS_Golbarg.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carts
        public async Task<ActionResult> Index()
        {
            var carts = db.Carts.Include(c => c.Mixer).Include(c => c.PayCoin.User);
            return View(await carts.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            //ViewBag.DestinationHairColors = db.HairColors.ToList();
            var haircolor =  db.HairColors.ToList();
            CreateCartViewModel ccvm = new CreateCartViewModel
            {
                HairColors = haircolor

            };
            return View(ccvm);
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for    //[Bind(Include = "ActualHairColorID,DestinationHairColorID")] CreateCartViewModel CCVM
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(int? DestinationHairColorID, int? ActualHairColorID)
        {
            

                Mixer _mixer = db.Mixers.SingleOrDefault(m => m.ActualHairColorID == ActualHairColorID && m.DestinationHairColorID == DestinationHairColorID);

                string _userID = User.Identity.GetUserId();
                // Balance _balance =await db.Balances.Include(m=>m.Pays).SingleOrDefaultAsync(m => m.UserID == _userID);

                var PayCoins = db.PayCoins.Include(m => m.User).Where(m => m.UserID == _userID).ToList();


                var bal = 0;

                foreach (var item in PayCoins)
                {

                    if (item.InOutType == PayCoin.PayInType)
                    {
                        bal += item.NumberOfCoins;
                    }
                    else if (item.InOutType == PayCoin.PayOutType)
                    {
                        bal -= item.NumberOfCoins;
                    }

                }


            //Pay _pay=new Pay()
            //{
            //    Balance =await db.Balances.Include(m=>m.User).Where(m=>m.UserID==_userID).SingleOrDefaultAsync(),

            //};

            if (bal > 0)
            {
                //PayCoin coin = new PayCoin()
                //{
                //    InOutType = PayCoin.PayOutType,
                //    NumberOfCoins = 1,
                //    RegisterDate = DateTime.Today,
                //    UserID = _userID

                //};

                //db.PayCoins.Add(coin);
                //db.SaveChanges();


                Cart _newCart = new Cart()
                {
                    Mixer = _mixer,
                    PayCoin = new PayCoin()
                    {
                        InOutType = PayCoin.PayOutType,
                        NumberOfCoins = 1,
                        RegisterDate = DateTime.Today,
                        UserID = _userID,
                        //Pay = new Pay()
                        //{
                        //    Balance =db.Balances.Where(m=>m.UserID==_userID).SingleOrDefault(),
                        //    InOutType = Pay.PayOut,
                        //    PayPlan = null,
                        //    State = true
                        //}

                    },
                    RegisterDate = DateTime.Now,
                    StartDay = DateTime.Now,
                    ConfirmDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(int.Parse(db.Settings.Where(m => m.Setting_Name == Setting.SHOWDAYS_NO).SingleOrDefault().Setting_Value))


                };

                db.Carts.Add(_newCart);
                db.SaveChanges();

                return Json(_mixer);
            }
            else
            {

                Tuple<bool, string> msg;
                bool type = false;
                string text = "موجودی شما کافی نیست";
                msg = new Tuple<bool, string>(type, text);

                return Json(msg);

            }

        }

        // GET: Carts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.SingleOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.MixerId = new SelectList(db.Mixers, "Id", "Mix", cart.MixerId);
            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber", cart.PayCoinId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MixerId,PayId,RegisterDate,ConfirmDate,EndDate,StartDay")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MixerId = new SelectList(db.Mixers, "Id", "Mix", cart.MixerId);
            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber", cart.PayCoinId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult get_ActualHairColors(int DestinationHairColorID)
        {
            List<Mixer> Mixers = db.Mixers.Include(m => m.ActualHairColor).Where(m => m.DestinationHairColorID == DestinationHairColorID).ToList();
            List<HairColor> a = new List<HairColor>();
            foreach (var item in Mixers)
            {
                a.Add(item.ActualHairColor);
            }
            List<HairColorViewModel> hr = new List<HairColorViewModel>();
            Mapper.Map(a, hr);
            return Json(hr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult get_DecolorState(int DestinationHairColorID, int ActualHairColorID)
        {
            Mixer _mixer = db.Mixers.SingleOrDefault(m => m.DestinationHairColorID == DestinationHairColorID && m.ActualHairColorID == ActualHairColorID);



            Tuple<bool, string> msg;
            string decolor = null;
            if (_mixer != null)
            {
                decolor = _mixer.DeColor;
                msg = new Tuple<bool, string>(true, decolor);
            }
            else
            {
                decolor = "nothing";
                msg = new Tuple<bool, string>(false, decolor);
            }

            return Json(msg);
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
