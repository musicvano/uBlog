using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Web.Models
{
    public class TagModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> Posts { get; set; }
    }
}