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
            var post = db.Query<Post>().SingleOrDefault(p => p.Slug == slug);
            if (post != null)
            {
                post.Comments = db.Query<Comment>().Where(c => c.PostId == post.Id).OrderBy(c => c.DateCreated).ToList();                
                post.Tags = db.Fetch<Tag>("SELECT * FROM Tag INNER JOIN PostTag ON Tag.Id = PostTag.TagId WHERE PostTag.PostId = @0", post.Id);
            }
            return post;
        }

        public List<Post> GetAll()
        {
            return db.Query<Post>().OrderBy(p => p.Id).ToList();
        }

        public List<Post> GetByPage(int pageIndex, int pageSize)
        {
            return db.Query<Post>().Limit((pageIndex - 1) * pageSize, pageSize).OrderBy(p => p.DateCreated).ToList();            
        }
    }
}