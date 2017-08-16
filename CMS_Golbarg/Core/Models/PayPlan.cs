using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS_Golbarg.Core.Models
{
    public class PayPlan
    {
        [Key]
        public int Id { set; get; }

        [Display(Name = "نام طرح")]
        public string PlanName { set; get; }

        [Display(Name = "توضیحات")]
        public string PlanDes { set; get; }

        [Display(Name = "قیمت واحد")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Fi { set; get; }

        [Display(Name = "تعداد سکه")]
        public int NumberOfCoin { set; get; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاریخ شروع طرح")]
        public DateTime? StartDate { set; get; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاریخ پایان طرح")]
        public DateTime? EndDate { set; get; }

        [Display(Name = "وضعیت")]
        public bool State { set; get; }

        public virtual IEnumerable<Pay> Pays { set; get; }

        [Display(Name = "قیمت کل")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public int PayAmount
        {
            get { return NumberOfCoin * Fi; }
        }
    }
}