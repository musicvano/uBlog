using System.Collections.Generic;
using uBlog.Core.Infrastructure;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(string username, string email, string password, int[] roles);
        User GetUser(int userId);
        List<Role> GetUserRoles(string username);
    }
}