using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Data.Repositories
{
    //public interface IAlbumRepository : IEntityBaseRepository<Album> { }

    public interface IErrorRepository : IEntityBaseRepository<Error> { }

    //public interface IPhotoRepository : IEntityBaseRepository<Photo> { }

    public interface IRoleRepository : IEntityBaseRepository<Role> { }

    public interface IUserRepository : IEntityBaseRepository<User>
    {
        User GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }

    public interface IUserRoleRepository : IEntityBaseRepository<UserRole> { }
}
