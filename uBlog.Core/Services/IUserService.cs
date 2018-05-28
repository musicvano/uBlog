using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    /// <summary>
    /// Provides methods for retrieving and updating user data
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Returns a user by Id
        /// </summary>
        User Get(int Id);

        /// <summary>
        /// Returns all users
        /// </summary>
        List<User> GetAll();

        /// <summary>
        /// Returns admin user account information
        /// </summary>
        User GetAdmin();

        /// <summary>
        /// Updates user in database
        /// </summary>
        void Update(User user);
    }
}