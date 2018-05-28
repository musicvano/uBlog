using System.Collections.Generic;
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

        public User Get(int Id)
        {
            return context.Users.SingleOrDefault(p => p.Id == Id);
        }

        public User GetAdmin()
        {
            return Get(1);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}