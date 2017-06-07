using Microsoft.EntityFrameworkCore;
using uBlog.Data.Entities;

namespace uBlog.Data
{
    /// <summary>
    /// Main data context of the blog engine
    /// </summary>
    public interface IBlogContext
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<PostTag> PostTags { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Config> Configs { get; set; }

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        int SaveChanges();
    }
}