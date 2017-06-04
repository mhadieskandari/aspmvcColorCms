using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Client.Models
{
    public class Setting
    {
        public int id { set; get; }

        [Display(Name="نام تنظیمات")]
        public string Setting_Name { set; get; }

        [Display(Name = "مقدار تنظیمات")]
        public string Setting_Value { set; get; }


        [NotMapped]
        public const string TRNSACTION_FI = "TRNSACTION_FI";


    }
}