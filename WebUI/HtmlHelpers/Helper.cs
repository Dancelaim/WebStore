using System;
using System.Collections.Generic;
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
        public static string AdminIsSelected(this HtmlHelper html, string item = null)
        {
            const string cssClass = "active";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];

            return item == currentAction ? cssClass : String.Empty;
        }
        public static MvcHtmlString SetTabsForOptions(this HtmlHelper html, IEnumerable<string> tabNames)
        {
            StringBuilder result = new StringBuilder();
            foreach (string tab in tabNames)
            {
                TagBuilder divTag = new TagBuilder("div");
                TagBuilder spanTag = new TagBuilder("span");
                spanTag.AddCssClass("remove-option");
                divTag.InnerHtml = tab.ToString() + spanTag;
                divTag.AddCssClass("opt-head");
                divTag.GenerateId(tab.ToString());
                result.Append(divTag.ToString());
            }

            return MvcHtmlString.Create(result.ToString()); ;
        }
        public static IDisposable BeginCollectionItem<TModel>(this HtmlHelper<TModel> html, string collectionName)
        {
            string itemIndex = Guid.NewGuid().ToString();
            string collectionItemName = String.Format("{0}[{1}]", collectionName, itemIndex);

            TagBuilder indexField = new TagBuilder("input");
            indexField.MergeAttributes(new Dictionary<string, string>() {
                            { "name", String.Format("{0}.Index", collectionName) },
                            { "value", itemIndex },
                            { "type", "hidden" },
                            { "autocomplete", "off" }
                                });

            html.ViewContext.Writer.WriteLine(indexField.ToString(TagRenderMode.SelfClosing));
            return new CollectionItemNamePrefixScope(html.ViewData.TemplateInfo, collectionItemName);
        }

        private class CollectionItemNamePrefixScope : IDisposable
        {
            private readonly TemplateInfo _templateInfo;
            private readonly string _previousPrefix;

            public CollectionItemNamePrefixScope(TemplateInfo templateInfo, string collectionItemName)
            {
                this._templateInfo = templateInfo;

                _previousPrefix = templateInfo.HtmlFieldPrefix;
                templateInfo.HtmlFieldPrefix = collectionItemName;
            }

            public void Dispose()
            {
                _templateInfo.HtmlFieldPrefix = _previousPrefix;
            }
        }
    }

}