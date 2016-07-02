using System;
using System.Collections.Generic;

namespace uBlog.Data.Entities
{
    public class User : IEntity
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}