using System.ComponentModel.DataAnnotations;

namespace uBlog.Web.Models
{
    public class RegisterModel
    {
        [Required, EmailAddress, MaxLength(256)]
        public string Email { get; set; }

        [Required, MinLength(5, ErrorMessage = "Password should contain at least 5 characters"), DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}