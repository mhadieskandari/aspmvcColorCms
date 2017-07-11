using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.ViewModel
{
    public class ShowProfileViewModel
    {
        public int NumOfCoins { set; get; }

        public decimal AccountBal { set; get; }

        public Areas.Admin.Models.ApplicationUser User { set; get; }

    }
}