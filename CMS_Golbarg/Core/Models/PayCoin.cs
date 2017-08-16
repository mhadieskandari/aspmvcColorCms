using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
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


        public int? PayId { set; get; }


        [ForeignKey("UserID")]
        public ApplicationUser User { set; get; }
        
        public string UserID { set; get; }


        [Display(Name = "تعداد سکه ها")]
        public int NumberOfCoins { set; get; }

        [Display(Name = "نوع")]
        public  byte InOutType { set; get; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime RegisterDate { set; get; }

        [Display(Name = "نوع")]
        public string _getPayTypeName
        {
            get
            {
                if (InOutType == 1)
                {
                    return "خرید";
                }
                else if (InOutType == 2)
                {
                    return "مصرف";
                }
                else
                {
                    return "نا معلوم";
                }
            }
        }

        public static byte PayInType = 1;

        public static byte PayOutType = 2;





    }
}