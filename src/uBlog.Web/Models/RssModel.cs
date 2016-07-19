using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Xml;
using uBlog.Core.Infrastructure;
using uBlog.Core.Services;

namespace uBlog.Web.Models
{
    public class RssModel
    {
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string Description { get; private set; }
        public List<RssItemModel> Items { get; private set; }

        public RssModel(IConfigService configService, IUserService userService, IPostService postService)
        {
            var admin = userService.GetAdmin();
            var config = configService.Get();
            var posts = postService.GetAll();
            //postService.EncodeContent(posts);
            Title = $"Blog - {admin.Username}";
            Link = config.DomainUrl;
            Description = Title;
            Items = posts.Select(p => new RssItemModel
            {
                Title = p.Title,
                Link = $"{config.DomainUrl}/posts/{WebUtility.UrlEncode(p.Slug)}",                
                Description = p.Content,
                Guid = $"{config.DomainUrl}/posts/{p.Id}",
                PubDate = p.DateCreated.ToString("r"),
                Author = $"{admin.Email} ({admin.Username})" 
            }).ToList();
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
                xml.WriteStartElement("rss");
                xml.WriteAttributeString("version", "2.0");
                xml.WriteAttributeString("xmlns", "atom", null, "http://www.w3.org/2005/Atom");
                xml.WriteStartElement("channel");
                xml.WriteElementString("title", Title);
                xml.WriteElementString("link", Link);
                xml.WriteElementString("description", Description);
                xml.WriteElementString("generator", $"uBlog {AppSettings.Version} https://github.com/musicvano/uBlog");
                xml.WriteStartElement("atom", "link", null);
                xml.WriteAttributeString("href", $"{Link}/rss");
                xml.WriteAttributeString("rel", "self");
                xml.WriteAttributeString("type", "application/rss+xml");
                xml.WriteEndElement();
                foreach (var item in Items)
                {
                    xml.WriteStartElement("item");
                    xml.WriteElementString("title", item.Title);
                    xml.WriteElementString("link", item.Link);
                    xml.WriteElementString("description", item.Description);
                    xml.WriteElementString("guid", item.Guid);
                    xml.WriteElementString("pubDate", item.PubDate);
                    xml.WriteElementString("author", item.Author);
                    xml.WriteEndElement();
                }
                xml.WriteEndElement();
                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
            return writer.ToString();
        }
    }
}