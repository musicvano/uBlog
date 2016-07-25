using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    /// <summary>
    /// Provides methods for retrieving and storing blog posts 
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Returns post by Id
        /// </summary>
        Post Get(int Id);

        /// <summary>
        /// Returns all posts sorted by date
        /// </summary>
        List<Post> GetAll();

        /// <summary>
        /// Returns post by slug 
        /// </summary>
        Post GetBySlug(string slug);

        /// <summary>
        /// Returns posts by page number
        /// </summary>
        /// <param name="page">Current page number</param>
        /// <param name="pageSize">Count posts per a page</param>
        List<Post> GetByPage(int page, int pageSize);

        /// <summary>
        /// Returns posts by tag Id
        /// </summary>
        /// <param name="tagId">Tag Id</param>
        /// <param name="page">Current page number</param>
        /// <param name="pageSize">Count pages per a page</param>
        List<Post> GetByTag(int tagId, int page, int pageSize);

        /// <summary>
        /// Returns all posts that contain given text in title, content or tag
        /// </summary>
        /// <param name="text">Text for search</param>
        List<Post> GetByText(string text);

        /// <summary>
        /// Updates post in database
        /// </summary>
        /// <param name="post"></param>
        void Update(Post post);

        /// <summary>
        /// Replaces Markdown content of the post with HTML
        /// </summary>
        void EncodeContent(Post post);

        /// <summary>
        /// Replaces Markdown content of he posts with HTML
        /// </summary>
        void EncodeContent(ICollection<Post> posts);
    }
}
