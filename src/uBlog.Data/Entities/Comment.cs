namespace uBlog.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int PostId { get; set; }
        //public Post Post { get; set; }
    }
}