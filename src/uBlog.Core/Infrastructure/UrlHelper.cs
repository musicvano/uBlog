using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace uBlog.Core.Infrastructure
{
    public class UrlHelper
    {
        /// <summary>
        /// Returns url-safe slug by given text
        /// </summary>
        /// <param name="text">Title for url</param>
        /// <returns></returns>
        public static string GetSlug(string text)
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

        /// <summary>
        /// Removes http://, https:// and www prefixes from url
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="url">Url string</param>
        /// <returns></returns>
        public static string CleanUrl(string url)
        {
            return Regex.Replace(url, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase);
        }
    }
}