using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Areas.Client.Models;
using CMS_Golbarg.ViewModel;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;

namespace CMS_Golbarg.Areas.Client.Controllers
{
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carts
        public async Task<ActionResult> Index()
        {
            var carts = db.Carts.Include(c => c.Mixer).Include(c => c.Pay);
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
            ViewBag.DestinationHairColors = db.HairColors.ToList();
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for    //[Bind(Include = "ActualHairColorID,DestinationHairColorID")] CreateCartViewModel CCVM
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(int ActualHairColorID,int DestinationHairColorID)
        {
            if (ModelState.IsValid)
            {
                //Mixer _mixer = await db.Mixers.SingleOrDefaultAsync(m => m.ActualHairColorID == CCVM.ActualHairColorID && m.DestinationHairColorID == CCVM.DestinationHairColorID);


                Mixer _mixer = await db.Mixers.SingleOrDefaultAsync(m => m.ActualHairColorID == ActualHairColorID && m.DestinationHairColorID == DestinationHairColorID);
                decimal fi =Decimal.Parse( db.Settings.SingleOrDefault(m => m.Setting_Name == Setting.TRNSACTION_FI).Setting_Value);
                string _userID = User.Identity.GetUserId();
                Balance _balance =await db.Balances.Include(m=>m.Pays).SingleOrDefaultAsync(m => m.UserID == _userID);

                if (_balance.GetBalance() >= fi)
                {
                    Pay _pay = new Pay()
                    {
                        BalanceID = _balance.Id,
                        PayAmount = fi,
                        InOutType = Pay.PayOut,
                        PayDate = DateTime.Now
                    };

                    db.Pays.Add(_pay);
                    await db.SaveChangesAsync();

                    Cart _newCart = new Cart()
                    {
                        MixerId = _mixer.Id,
                        PayId = _pay.Id,
                        
                    };

                    db.Carts.Add(_newCart);
                    await db.SaveChangesAsync();

                    _pay.State = true;
                    db.Entry(_pay).State = EntityState.Modified;
                    await db.SaveChangesAsync();


                   


                    return Json(new { res = "created" });

                }
                else
                {
                    
                    return Json(new {res="notcreated" });

                }

                

               
                //return RedirectToAction("Index");
            }
            //ViewBag.DestinationHairColors = db.HairColors.ToList();
            //return View();

            return Json(new { res = "notcreated" });
        }

        // GET: Carts/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.MixerId = new SelectList(db.Mixers, "Id", "Mix", cart.MixerId);
            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber", cart.PayId);
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
            ViewBag.PayId = new SelectList(db.Pays, "Id", "TransitionOfBankNumber", cart.PayId);
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
            List<Mixer> Mixers = db.Mixers.Include(m=>m.ActualHairColor).Where(m => m.DestinationHairColorID == DestinationHairColorID).ToList();
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
            string decolor = _mixer.DeColor;
            return Json(decolor);
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
