using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            Title = $"Blog - {admin.Username}";
            Link = config.DomainUrl;
            Items = posts.Select(p => new RssItemModel
            {
                Title = p.Title,
                Link = $"{config.DomainUrl}/posts/{p.Slug}",
                Description = String.Join(", ", p.PostTags.Select(pt => pt.Tag.Name)),
                Guid = $"{config.DomainUrl}/posts/{p.Id}"
            }).ToList();
            Description = String.Join(", ", Items.Select(i => i.Description));
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
                xml.WriteStartElement("channel");
                xml.WriteElementString("title", Title);
                xml.WriteElementString("link", Link); 
                xml.WriteElementString("description", Description);
                foreach (var item in Items)
                {
                    xml.WriteStartElement("item");
                    xml.WriteElementString("title", item.Title);
                    xml.WriteElementString("link", item.Link);
                    xml.WriteElementString("description", item.Description);
                    xml.WriteElementString("guid", item.Guid);
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