namespace uBlog.Web.Models
{
    public class RssItemModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Guid { get; set; }
        public string PubDate { get; set; }
        public string Author { get; set; }
    }
}