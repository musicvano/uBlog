namespace uBlog.Data.Entities
{
    public class Settings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageSize { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
    }
}