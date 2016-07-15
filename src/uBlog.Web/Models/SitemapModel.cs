using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using uBlog.Core.Infrastructure;
using uBlog.Core.Services;

namespace uBlog.Web.Models
{
    public class SitemapModel
    {
        public List<string> Urls { get; private set; }

        public SitemapModel(IConfigService configService, IPostService postService, ITagService tagService)
        {
            var config = configService.Get();
            var domain = config.DomainUrl;
            var posts = postService.GetAll();
            var tags = tagService.GetAll();

            Urls = new List<string>();
            Urls.Add($"{domain}");
            Urls.Add($"{domain}/posts");
            Urls.Add($"{domain}/tags");
            Urls.Add($"{domain}/about");
            Urls.Add($"{domain}/rss");
            Urls.AddRange(posts.Select(p => $"{domain}/posts/{p.Slug}"));
            Urls.AddRange(tags.Select(t => $"{domain}/tags/{t.Slug}"));
        }

        /// <summary>
        /// Returns Xml string
        /// </summary>
        public string XmlString()
        {
            var writer = new StringWriterUTF8();
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                IndentChars = "\t",
                WriteEndDocumentOnClose = true
            };
            using (var xml = XmlWriter.Create(writer, settings))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
                foreach (var url in Urls)
                {
                    xml.WriteStartElement("url");
                    xml.WriteElementString("loc", url);
                    xml.WriteElementString("changefreq", "daily");
                    xml.WriteEndElement();
                }
                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
            return writer.ToString();
        }
    }
}