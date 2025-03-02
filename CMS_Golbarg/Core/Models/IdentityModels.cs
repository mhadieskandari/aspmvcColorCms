﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS_Golbarg.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CMS_Golbarg.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

       //public virtual List<Balance> Balances { set; get; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);


           
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            foreach (var role in Models.Roles.GetRoles())
            {
                if (!roleManager.RoleExists(role.RoleName))
                {
                    roleManager.Create(new IdentityRole(role.RoleName));
                }
            }
           
           



            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Content> Contents { set; get; }
        public DbSet<PaintingWay> PaintingWays { set; get; }
        public DbSet<Mixer> Mixers { set; get; }
        public DbSet<HairColor> HairColors { set; get; }
        public DbSet<Pay> Pays { set; get; }
        public DbSet<Balance> Balances { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<Setting> Settings { set; get; }

        public DbSet<PayPlan> PayPlans { set; get; }

        public DbSet<PayCoin> PayCoins { set; get; }


        public ApplicationDbContext()
            : base("gobarg", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}