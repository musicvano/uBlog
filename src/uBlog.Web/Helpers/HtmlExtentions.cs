﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace uBlog.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString CleanUrl(this IHtmlHelper helper, string url)
        {
            var str = Regex.Replace(url, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase);
            return new HtmlString(str);
        }
    }
}