using CMS_Golbarg.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CMS_Golbarg.Core.Models;

namespace CMS_Golbarg.ViewModel
{
    public class CreateRoleViewModel
    {
        public CreateRoleViewModel()
        {
            Roles = new List<Role>();
        }
        public List<Role> Roles { set; get; }

        [Required(ErrorMessage ="این فیلد اجباریست")]
        public string UserId { set; get; }

        [Display(Name ="دسترسی")]
        [Required(ErrorMessage = "این فیلد اجباریست")]
        public string RoleId { set; get; }
        public string UserName { set; get; }

    }
}