using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS_Golbarg.Areas.Admin.Models;

namespace CMS_Golbarg.ViewModel
{
    public class UserItemViewModel
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationUser User { set; get; }

        public int NumberOfCoin {
            get
            {
                int res = 0;
                var coins = db.PayCoins.Where(m => m.Pay.Balance.UserID == User.Id);
                foreach (var coin in coins)
                {
                    if (coin.InOutType == 1)
                    {
                        res +=coin.NumberOfCoins;
                    }
                    else if(coin.InOutType==2)
                    {
                        res -= coin.NumberOfCoins;
                    }
                }

                return res;
            }
        }

        public decimal PayAmount
        {
            get
            {
                decimal res = 0;
                var pays = db.Pays.Where(m => m.Balance.UserID == User.Id);
                foreach (var pay in pays)
                {
                    if (pay.InOutType == 1)
                    {
                        res += pay.PayAmount;
                    }
                    else if (pay.InOutType == 2)
                    {
                        res -= pay.PayAmount;
                    }
                }
                return res;
            }
        }



    }
}