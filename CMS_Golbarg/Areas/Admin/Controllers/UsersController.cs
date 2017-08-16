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
using CMS_Golbarg.Core.Models;
using CMS_Golbarg.ViewModel;

namespace CMS_Golbarg.Areas.Admin.Controllers
{

    [Authorize(Roles = Roles.Administrator + "," + Roles.Owner)]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ApplicationUsers
        public ActionResult Index()
        {
            var Users = db.Users.ToList();
            List<UserItemViewModel> _users=new List<UserItemViewModel>();
            foreach (var user in Users)
            {
                _users.Add(new UserItemViewModel
                {
                    User =user 
                        
                });
            }

            return View(_users);
        }

        // GET: Admin/ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser =  db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Admin/ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: Admin/ApplicationUsers/Edit/5
        public  ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: Admin/ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser =  db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser =  db.Users.Find(id);
            db.Users.Remove(applicationUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult Permission(string userid)
        {
            

            if (!string.IsNullOrEmpty(userid))
            {
                
                var user = db.Users.Where(m => m.Id == userid).FirstOrDefault();
                var _Roles = new List<Role>();
                foreach (var item in user.Roles)
                {
                    _Roles.Add(new Role()
                    {
                        RoleValue = item.RoleId,
                        RoleName = db.Roles.FirstOrDefault(m => m.Id == item.RoleId).Name
                    });
                }
                var model=new RoleViewModel()
                    {
                        Roles=_Roles,
                        UserId=user.Id,
                        UserName=user.UserName  
                    };
                return View(model);
            }
            return HttpNotFound();

        }

        //[HttpPost]
        public ActionResult RemoveRole(string userId,string roleId)
        {
            ApplicationUser user=new ApplicationUser();
            if (!string.IsNullOrEmpty(userId)&& !string.IsNullOrEmpty(roleId))
            {
                
                user = db.Users.Where(m => m.Id == userId).FirstOrDefault();
                if (user != null )
                {
                    var role=user.Roles.SingleOrDefault(m => m.RoleId == roleId);
                    if (role != null)
                    {
                        user.Roles.Remove(role);
                        db.SaveChanges();
                        TempData["msg"] = "دسترسی کاربر با موفقیت حذف شد";
                    }
                }
                else
                {
                    TempData["msg"] = "کاربر مورد نظر وجو ندارد";
                }
                
            }
            else
            {
                TempData["msg"] = "اطلاعات ورودی ناقص می باشد";
            }
            return RedirectToAction("Permission",new { userid=user.Id});

        }

        public ActionResult AddRole(string userId)
        {
            ApplicationUser user ;
            CreateRoleViewModel model;
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userId))
            {

                user = db.Users.FirstOrDefault(m => m.Id == userId);
                if (user != null)
                {
                    model = new CreateRoleViewModel();
                    List<Roles> roles = new List<Roles>();
                    foreach(var role in db.Roles.ToList())
                    {
                        model.Roles.Add(new Role()
                        {
                            RoleName = role.Name,
                            RoleValue=role.Id
                        });
                    }
                    
                    model.UserId = user.Id;
                    model.UserName = user.UserName;
                    return View(model);
                }
                else
                {
                    TempData["msg"] = "کاربر مورد نظر وجو ندارد";
                    return RedirectToAction("Permission");                    
                }
            }
            else
            {
                return HttpNotFound();
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(m => m.Id == model.UserId);
                if (user.Roles.Where(m => m.RoleId == model.RoleId).Any())
                {
                    TempData["msg"] = "این سطح دسترسی وجود دارد";
                    return RedirectToAction("AddRole", new { userid = model.UserId });
                }
                else
                {
                    user.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole() {RoleId=model.RoleId,UserId=model.UserId });
                    db.SaveChanges();
                    TempData["msg"] = "سطح دسترسی با موفقیت ایجاد شد";
                    return RedirectToAction("Permission", new { userid = model.UserId });
                }

            }
            TempData["msg"] = "خطا";
            return RedirectToAction("Permission", new { userid = model.UserId });
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
