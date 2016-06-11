namespace uBlog.Data.Entities
{
    public class Config
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string About { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Github { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Skype { get; set; }
        public string Location { get; set; }
        public int PageSize { get; set; }
    }
}