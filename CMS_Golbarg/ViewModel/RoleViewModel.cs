using CMS_Golbarg.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.ViewModel
{
    public class RoleViewModel
    {
        public List<Role> Roles { set; get; }
        public string UserId { set; get; }
        public string UserName { set; get; }

    }
}