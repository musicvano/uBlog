using System;
using System.Linq;
using uBlog.Data;
using uBlog.Data.Entities;

namespace uBlog.Core.Services
{
    public class UserService: IUserService
    {
        private readonly IBlogContext context;
        private readonly IEncryptionService encryptionService;

        public UserService(IBlogContext context, IEncryptionService encryptionService)
        {
            this.context = context;
            this.encryptionService = encryptionService;
        }

        public User GetAdmin()
        {
            return context.Users.SingleOrDefault(u => u.Id == 1);
        }

        public User CreateAdmin(string email, string password)
        {
            var passwordSalt = encryptionService.CreateSalt();
            var user = new User
            {
                Username = "Username",
                Email = email,
                About = "Tell a little about yourself",
                Photo = "default.png",
                Url = "http://user.com",
                Github = "https://github.com/user",
                Facebook = "https://www.facebook.com/user",
                Twitter = "https://twitter.com/user",
                Skype = "user",
                Location = "Country",
                HashedPassword = encryptionService.EncryptPassword(password, passwordSalt),
                Salt = passwordSalt,
                DateCreated = DateTime.Now
            };
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}