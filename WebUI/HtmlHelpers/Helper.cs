using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

using WebUI.Models;

namespace WebUI.HtmlHelpers
{
    public static class Helper
    {
        public static string MakeActiveClass(this UrlHelper urlHelper, string controller)
        {
            string result = "active";

            string controllerName = urlHelper.RequestContext.RouteData.Values["controller"].ToString();

            if (!controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
            {
                result = null;
            }

            return result;
        }
        public static string IsSelected(this HtmlHelper html, string category = null)
        {
            const string cssClass = "active";
            var currentCategory = (string)html.ViewContext.RouteData.Values["categoryName"];

            return category == currentCategory ? cssClass : String.Empty;
        }

    }
}