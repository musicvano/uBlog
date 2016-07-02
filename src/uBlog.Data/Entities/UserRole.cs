namespace uBlog.Data.Entities
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}