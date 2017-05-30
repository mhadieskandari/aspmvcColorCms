using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.ViewModel
{
    public class HairColorCardViewModel
    {
        public int Id { set; get; }

        [Display(Name="نام بین المللی")]
        public string InterNationalColorName { set; get; }

        [Display(Name = "کد بین المللی")]
        public string InterNationalColorCode { set; get; }

        [Display(Name = "کد فارسی")]
        public string PersianColorCode { set; get; }

        [Display(Name = "نام فارسی")]
        public string PersianColorName { set; get; }

        [Display(Name = "نمونه عکس")]
        public byte[] ImagePic { set; get; }
    }
}