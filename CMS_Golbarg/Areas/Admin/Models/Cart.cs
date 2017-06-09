using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class Cart
    {

        public int Id { set; get; }

        [ForeignKey("MixerId")]
        public Mixer Mixer { set; get; }
        public int MixerId { set; get; }

        [ForeignKey("PayId")]
        public Pay Pay { set; get; }
        public int PayId { set; get; }


        [Display(Name ="تاریخ ثبت")]
        public DateTime? RegisterDate { set; get; }

        [Display(Name = "تاریخ تایید")]
        public DateTime? ConfirmDate { set; get; }


        [Display(Name = "تاریخ اتمام نمایش")]
        public DateTime? EndDate { set; get; }


        [Display(Name = "تاریخ شروع نمایش")]
        public DateTime? StartDay { set; get; }

       





    }
}