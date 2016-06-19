using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace uBlog.Web.Helpers
{
    public static class UrlExtentions
    {
        public static string GetSlug(this IUrlHelper  helper, string text)
        {
            //First to lower case 
            text = text.ToLowerInvariant();

            //Remove all accents
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            text = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            //Replace spaces, dots, ++, #
            text = Regex.Replace(text, @"[\s\.]", "-", RegexOptions.Compiled);
            text = Regex.Replace(text, @"[+][+]", "pp", RegexOptions.Compiled);
            text = Regex.Replace(text, @"#", "sharp", RegexOptions.Compiled);

            //Remove invalid chars 
            text = Regex.Replace(text, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

            //Trim dashes from end 
            text = text.Trim('-', '_');

            //Replace double occurences of - or \_ 
            text = Regex.Replace(text, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return text;
        }
    }
}