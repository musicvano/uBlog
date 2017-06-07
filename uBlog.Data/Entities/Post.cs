using System;
using System.Collections.Generic;

namespace uBlog.Data.Entities
{
    /// <summary>
    /// Post entity
    /// </summary>
    public class Post
    {
        public int Id { get; set; }

        /// <summary>
        /// Title of the post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Short url slug of the post
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Markdown content of the post
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Date and time post have been created
        /// </summary>
        public DateTime DateCreated { get; set; }
        
        /// <summary>
        /// Post is publishen when this property is false
        /// </summary>
        public bool Draft { get; set; }

        /// <summary>
        /// Tags of the post
        /// </summary>
        public List<PostTag> PostTags { get; set; }
    }
}