using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Models
{
    public class Content
    {
        [Display(Name ="ID")]
        public int? ID{ set; get;  }

        [Display(Name = "عنوان")]
        [StringLength(100)]
        [Required]
        public string Title { set; get; }

        [Display(Name = "خلاصه متن")]
        [StringLength(300)]
        public string Summury_Content { set; get; }

        [Display(Name = "متن")]
        public string Full_Content { set; get; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime? Date_Register { set; get; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime? Date_Publish { set; get; }

        [Display(Name = "کاربر ایجاد کننده")]
        [StringLength(128)]
        public string UserID_Creator { set; get; }

        [ForeignKey("UserID_Creator")]
        public virtual ApplicationUser user { set; get; }

        [Display(Name = "سطح دسترسی بیننده")]
        public int? MemberTypeView { set; get; }        

    }
}