using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class Pay
    {
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
        public Decimal PayAmount { set; get; }

        [Display(Name ="وضعیت پرداخت")]
        public Boolean State { set; get; }

        [Display(Name ="شماره تراکنش بانک")]
        public string TransitionOfBankNumber { set; get; }

        [Display(Name ="نوع پرداخت")]
        public byte InOutType { set; get; }

        [NotMapped]
        public static byte PayIn = 1;

        [NotMapped]
        public static byte PayOut = 2;


    }
}