using System;
using System.Web.Mvc;
using Training.Web.ActionFilters;

namespace Training.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidateAntiForgeryTokenFilter());
        }
    }
}