﻿using System.Web;
using System.Web.Mvc;

namespace CMS_Golbarg
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new RequireHttpsAttribute());
        }
    }
}
