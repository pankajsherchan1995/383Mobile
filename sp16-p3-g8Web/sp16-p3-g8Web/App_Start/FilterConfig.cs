﻿using System.Web;
using System.Web.Mvc;

namespace sp16_p3_g8Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}