using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Training.Web.Extensions
{
    public static class TableSortExtensions
    {
        // <th class="asc">
        //    @Html.ActionLink(Html.DisplayNameFor(p => p.Anrede).ToString(),
        //                     "Sort", new {property = "Anrede", direction=ViewBag.sortAnrede})
        //</th>
        public static MvcHtmlString TableSortLink<TModel, TValue>(
            this HtmlHelper<IEnumerable<TModel>> html,
            Expression<Func<TModel, TValue>> expression,
            string action,
            string propertyParameterName = "property",
            string directionParameterName = "direction"
            )
        {
            return html.TableSortLink(expression,
                                      action,
                                      new {},
                                      propertyParameterName,
                                      directionParameterName);
        }

        public static MvcHtmlString TableSortLink<TModel, TValue>(
            this HtmlHelper<IEnumerable<TModel>> html,
            Expression<Func<TModel, TValue>> expression,
            string action,
            object routeValues,
            string propertyParameterName = "property",
            string directionParameterName = "direction"
            )
        {
            var tagBuilder = new TagBuilder("th");
            var currentSortedName = html.GetQueryString(propertyParameterName);
            var direction = html.GetQueryString(directionParameterName) ?? "asc";
            var sortName = ExpressionHelper.GetExpressionText(expression);

            if (string.CompareOrdinal(currentSortedName, sortName) == 0)
            {
                tagBuilder.AddCssClass(direction);
                direction = string.CompareOrdinal(direction, "desc") != 0 ? "desc" : "asc";
            }
            else
            {
                direction = "asc";
            }
            var routeValueDictionary = new RouteValueDictionary(routeValues)
                                           {
                                               {propertyParameterName, sortName},
                                               {directionParameterName, direction}
                                           };

            tagBuilder.InnerHtml = html.ActionLink(
                html.DisplayNameFor(expression).ToString(), action, routeValueDictionary
                ).ToString();
            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        static string GetQueryString(this HtmlHelper html, string parameterName)
        {
            return html.ViewContext.HttpContext.Request.QueryString[parameterName];
        }
    }
}