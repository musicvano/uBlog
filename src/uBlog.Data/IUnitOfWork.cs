using System;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ITagRepository Tags { get; }
        IConfigRepository Configs { get; }
        int Save();
    }
}
