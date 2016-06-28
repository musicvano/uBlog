using System;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ITagRepository Tags { get; }
        ISettingRepository Settings { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IUserRoleRepository UserRoles { get; }
        IErrorRepository Errors { get; }
        int Save();
    }
}