using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
{
    public class Balance
    {
        [Key]
        public int Id { set; get; }

        [Display(Name ="شماره حساب سیستم")]
        public string BalanceNumber { set; get; }

        [ForeignKey("UserID")]
        public ApplicationUser User { set; get; }
        public string UserID { set; get; }

        [Display(Name="وضعیت")]
        public Boolean State { set; get; }

        public ICollection<Pay> Pays { set; get; }
                
        public decimal GetPayBalance()
        {
            decimal bal=0;


            if (Pays != null) { 
                foreach(var item in Pays)
                {
                    if (item.InOutType == Pay.PayIn)
                    {
                        bal += item.PayAmount;
                    }else if (item.InOutType == Pay.PayOut)
                    {
                        bal -= item.PayAmount;
                    }
                }
            }
            return bal;
        }

        


    }
}