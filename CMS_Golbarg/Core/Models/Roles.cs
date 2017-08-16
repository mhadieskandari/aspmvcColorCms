using System.Collections.Generic;

namespace CMS_Golbarg.Core.Models
{
    public class Roles
    {
        public const string Administrator = "Administrator";
        public const string Accountant = "Accountant";
        public const string Customer = "Customer";
        public const string Combiner = "Combiner";
        public const string Owner = "Owner";


        public static List<Role> GetRoles()
        {
            return new List<Role>()
            {
                new Role() { RoleName = Administrator,RoleValue = Administrator},
                new Role() { RoleName = Accountant,RoleValue = Accountant},
                new Role() { RoleName = Customer,RoleValue = Customer},
                new Role() { RoleName = Combiner,RoleValue = Combiner},
                new Role() { RoleName = Owner,RoleValue = Owner}

            };
        }




    }
    public class Role
    {


        public string RoleName { set; get; }

        public string RoleValue { set; get; }
    }
}