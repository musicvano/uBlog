using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IUserService
    {
        User GetAdmin();
        User CreateAdmin(string email, string password);
    }
}