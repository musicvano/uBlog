using System;
using System.Collections.Generic;

namespace uBlog.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Draft { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}