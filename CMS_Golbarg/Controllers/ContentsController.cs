using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS_Golbarg.Models;
using AutoMapper;

namespace CMS_Golbarg.Controllers
{
    public class ContentsController : Controller
    {
        ApplicationDbContext _context;
        public ContentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customer
        public ActionResult Index()
        {
            //var contents = _context.Contents.ToList();

            //return View(contents);
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Content content)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", content);
            }
            if (content.ID == null)
            {
                content.UserID_Creator = _context.Users.ToList()[0].Id;
                _context.Contents.Add(content);
                _context.SaveChanges();
            }
            else
            {
                var contentInDb = _context.Contents.SingleOrDefault(m=>m.ID==content.ID);
                Mapper.Map(content, contentInDb);
                _context.SaveChanges();
            }
            


            return RedirectToAction("Index", "Contents");
            
        }




    }
}