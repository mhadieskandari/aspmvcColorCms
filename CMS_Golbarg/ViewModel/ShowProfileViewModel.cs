using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS_Golbarg.Core.Models;

namespace CMS_Golbarg.ViewModel
{
    public class ShowProfileViewModel
    {
        public int NumOfCoins { set; get; }

        public decimal AccountBal { set; get; }

        public ApplicationUser User { set; get; }

    }
}