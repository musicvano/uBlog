namespace uBlog.Data.Entities
{
    public class Config
    {
        public int Id { get; set; }

        /// <summary>
        /// Count of posts per page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Domain name of the site (http://site.com)
        /// </summary>
        public string DomainUrl { get; set; }

        /// <summary>
        /// Disqus short name
        /// </summary>
        public string DisqusName { get; set; }

        /// <summary>
        /// AddThis profile ID
        /// </summary>
        public string AddThisId { get; set; }

        /// <summary>
        /// Google Analytics tracking ID
        /// </summary>
        public string GoogleId { get; set; }
    }
}