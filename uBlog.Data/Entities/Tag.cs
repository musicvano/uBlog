using System.Collections.Generic;

namespace uBlog.Data.Entities
{
    /// <summary>
    /// Tag entity
    /// </summary>
    public class Tag
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of the tag
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short url slug of the tag
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Posts with this tag
        /// </summary>
        public List<PostTag> PostTags { get; set; }
    }
}