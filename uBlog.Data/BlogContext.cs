using Microsoft.EntityFrameworkCore;
using uBlog.Data.Entities;

namespace uBlog.Data
{
    /// <summary>
    /// Main data context of the blog engine. It uses SQLite database. BlogContext represents a combination of the Unit Of Work and Repository patterns
    /// </summary>
    public class BlogContext : DbContext, IBlogContext
    {
        private readonly string connectionString;

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Config> Configs { get; set; }

        public BlogContext(string dbPath)
        {
            this.connectionString = $"Data Source={dbPath}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
                .HasKey(t => new { t.PostId, t.TagId });
            base.OnModelCreating(modelBuilder);
        }

        public bool EnsureCreated()
        {
            return Database.EnsureCreated();
        }
    }
}