using CMS_Golbarg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.ViewModel
{
    public class CreateCartViewModel
    {
               

        [Display(Name = "رنگ موی فعلی")]
        public int ActualHairColorID { set; get; }


        [Display(Name="رنگ موی درخواستی")]
        public int DestinationHairColorID { set; get; }






    }
}