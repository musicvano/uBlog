﻿using System;

namespace uBlog.Data.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Photo { get; set; }
        public string Url { get; set; }
        public string Github { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Skype { get; set; }
        public string Location { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public DateTime DateCreated { get; set; }
    }
}