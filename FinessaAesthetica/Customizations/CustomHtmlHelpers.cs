using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace FinessaAesthetica
{
    public static class CustomHtmlHelpers
    {

        public static IHtmlString DisplayForBoolean(this HtmlHelper html, bool value)
        {
            string htmlString = String.Format("<span class='fa fa-flag fa-fw text-success'></span>");

            if (!value)
            {
                htmlString = String.Format("<span class='fa fa-flag fa-fw text-danger'></span>");
            }
            return new HtmlString(htmlString);
        }

        public static IHtmlString DisplayForCurrency(this HtmlHelper html, float value)
        {
            string htmlString = String.Format("P{0}", value);
            return new HtmlString(htmlString);
        }


        public static IHtmlString DisplayForCheckbox(this HtmlHelper html, bool value)
        {
            string htmlString = String.Format("<span class='fa fa-check fa-fw text-success'></span>");

            if (!value)
            {
                htmlString = String.Format("<span class='fa fa-remove fa-fw text-danger'></span>");
            }
            return new HtmlString(htmlString);
        }

        public static IHtmlString DeleteAction(this HtmlHelper html, string controller, string action, int id)
        {
            return new HtmlString(String.Format("<a class='text-red' href='/{0}/{1}/{2}'><span class='fa fa-trash'></span></a>", controller, action, id));
        }

        public static IHtmlString Table(this HtmlHelper html)
        {
            return new HtmlString(String.Format("<a class='text-red' href='/{0}/{1}/{2}'><span class='fa fa-trash'></span></a>"));
        }    
    }
}