using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class PayCoin
    {
        [Key]
        public int Id { set; get; }

        //[ForeignKey("PayPlan")]
        //public PayPlan PayPlan { set; get; }

        //public int PayPlanId { set; get; }

        [ForeignKey("PayId")]
        public Pay Pay { set; get; }

        public int PayId { set; get; }

        public int NumberOfCoins { set; get; }

        public  byte InOutType { set; get; }

        public DateTime RegisterDate { set; get; }






    }
}