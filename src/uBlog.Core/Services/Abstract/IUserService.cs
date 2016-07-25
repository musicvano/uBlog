using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    /// <summary>
    /// Provides methods for retrieving and updating user data
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Returns admin user account information
        /// </summary>
        User GetAdmin();

        /// <summary>
        /// Creates admin user
        /// </summary>
        User CreateAdmin(string email, string password);
    }
}