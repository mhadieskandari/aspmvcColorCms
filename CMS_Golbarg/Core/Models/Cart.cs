using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
{
    public class Cart
    {
        [Key]
        public int Id { set; get; }

        [ForeignKey("MixerId")]
        public Mixer Mixer { set; get; }
        public int MixerId { set; get; }

        [ForeignKey("PayCoinId")]
        public PayCoin PayCoin { set; get; }
        public int PayCoinId { set; get; }


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