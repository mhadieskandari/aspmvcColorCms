using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class Pay
    {
        [Key]
        public int Id { set; get; }

        [ForeignKey("BalanceID")]
        public Balance Balance { set; get; }

        
        public int BalanceID { set; get; }

        [Display(Name ="تاریخ پرداخت")]
        
        public DateTime? PayDate { set; get; }

        [Display(Name = "تاریخ تایید")]
        public DateTime? ConfirmDate { set; get; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage ="مبلغ نمی تواند خالی باشد")]
        //[DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = false)]
        public Decimal PayAmount { set; get; }

        [Display(Name ="وضعیت پرداخت")]
        public Boolean State { set; get; }

        [Display(Name ="شماره تراکنش بانک")]
        public string TransitionOfBankNumber { set; get; }

        [Display(Name ="نوع پرداخت")]
        public byte InOutType { set; get; }

        [Display(Name = "نوع پرداخت")]
        public string InOutTypeName {
            get
            {
                if (InOutType == PayIn)
                {
                    return "خرید";
                }
                else if(InOutType==PayOut)
                {
                    return "مصرف";
                }
                else
                {
                    return "نامعلوم";
                }
            }
        }

        [ForeignKey("PayPlanId")]
        public PayPlan PayPlan { set; get; }

        
        public int PayPlanId { set; get; }

        public virtual IEnumerable<PayCoin> PayCoins { set; get; }



        [NotMapped]
        public static byte PayIn = 1;

        [NotMapped]
        public static byte PayOut = 2;

    }
}