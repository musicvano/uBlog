using System;

namespace uBlog.Data.Entities
{
    public class Error : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}