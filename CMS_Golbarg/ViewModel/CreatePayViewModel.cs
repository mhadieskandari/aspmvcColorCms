using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CMS_Golbarg.Areas.Admin.Models;

namespace CMS_Golbarg.ViewModel
{
    public class CreatePayViewModel
    {
        
        [Required]
        [Display(Name = "طرح پرداخت")]
        public int PayPlanId { set; get; }

        public string UserId { set; get; }

        [Display(Name = "نام کاربری")]
        public string UserName { set; get; }


        [Display(Name = "تعداد")]
        public int Count { set; get; }

        public IEnumerable<PayPlan> PayPlans { set; get; }
    }
}