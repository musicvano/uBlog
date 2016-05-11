﻿using System.Collections.Generic;

namespace uBlog.Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}