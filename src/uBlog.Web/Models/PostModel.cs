using System;
using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Web.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Draft { get; set; }
        public List<Tag> Tags { get; set; }
    }
}