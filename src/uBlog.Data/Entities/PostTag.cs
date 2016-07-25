namespace uBlog.Data.Entities
{
    /// <summary>
    /// Entity for many to many relationships between posts and tags
    /// </summary>
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}