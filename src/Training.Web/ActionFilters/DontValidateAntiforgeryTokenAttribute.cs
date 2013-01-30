using System;

namespace Training.Web.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DontValidateAntiforgeryTokenAttribute : Attribute
    {
    }
}