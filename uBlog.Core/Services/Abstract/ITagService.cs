using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    /// <summary>
    /// Provides methods for retrieving and storing blog tags
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Returns tag by short url slug
        /// </summary>
        Tag GetBySlug(string slug);

        /// <summary>
        /// Returns all tags sorted by name
        /// </summary>
        List<Tag> GetAll();
    }
}