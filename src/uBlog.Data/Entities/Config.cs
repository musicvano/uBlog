namespace uBlog.Data.Entities
{
    public class Config
    {
        public int Id { get; set; }
        public int PageSize { get; set; }
        public string DomainUrl { get; set; }
        public string DisqusName { get; set; }
    }
}