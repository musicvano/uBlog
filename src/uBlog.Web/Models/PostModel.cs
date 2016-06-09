using System;
using System.Collections.Generic;

namespace uBlog.Web.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Draft { get; set; }
        public List<TagModel> Tags { get; set; }
    }
}