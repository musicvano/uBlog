using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext context;

        public UnitOfWork()
        {
            context = new BlogContext();
            Posts = new PostRepository(context);
            Tags = new TagRepository(context);
            Settings = new SettingRepository(context);
            Roles = new RoleRepository(context);
            Users = new UserRepository(context, Roles);
            UserRoles = new UserRoleRepository(context);
            Errors = new ErrorRepository(context);
        }

        public IPostRepository Posts { get; private set; }
        public ITagRepository Tags { get; private set; }
        public ISettingRepository Settings { get; private set; }
        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IUserRoleRepository UserRoles { get; private set; }
        public IErrorRepository Errors { get; private set; }


        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}