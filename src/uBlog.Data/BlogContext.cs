using Microsoft.Data.Sqlite;
using NPoco;
using uBlog.Data.Repositories;
using uBlog.Data.Sqlite;

namespace uBlog.Data
{
    public class BlogContext : IBlogContext
    {
        private readonly IDatabase db;

        public BlogContext()
        {
            var conn = new SqliteConnection(@"Data Source=D:\blog.db");
            conn.Open();
            db = new Database(conn, DatabaseType.SQLite);
            Posts = new PostRepository(db);
            //Tags = new TagRepository(context);
            //Comments = new CommentRepository(context);
            //Settings = new SettingRepository(context);
        }

        public IPostRepository Posts { get; private set; }
        public ITagRepository Tags { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public ISettingRepository Settings { get; private set; }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}