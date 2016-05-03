using NPoco;
using System.Collections.Generic;
using uBlog.Data.Entities;
using uBlog.Data.Repositories;

namespace uBlog.Data.Sqlite
{
    public class PostRepository : IPostRepository
    {
        private readonly IDatabase db;
        public PostRepository(IDatabase db)
        {
            this.db = db;
        }

        public Post Get(int id)
        {
            return db.SingleOrDefaultById<Post>(id);
        }

        public Post GetBySlug(string slug)
        {
            return db.SingleOrDefault<Post>("SELECT * FROM Post WHERE Slug = @0", slug);
        }

        public List<Post> GetAll()
        {
            return db.Fetch<Post>("SELECT * FROM Post");
        }

        public List<Post> GetByPage(int pageIndex, int pageSize)
        {
            return db.Page<Post>(pageIndex, pageSize, "SELECT * FROM Post").Items;
        }
    }
}