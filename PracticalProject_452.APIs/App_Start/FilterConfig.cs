﻿using System.Web;
using System.Web.Mvc;

namespace PracticalProject_452.APIs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}