using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3_CRUD.Models
{
    public static class CustomHtmlHelper
    {
        public static IHtmlString Button(this HtmlHelper helper, string value)
        {
            TagBuilder tg = new TagBuilder("input");
            tg.Attributes.Add("type", "button");
            tg.Attributes.Add("value", value);

            return new MvcHtmlString(tg.ToString());
         }
    }
}