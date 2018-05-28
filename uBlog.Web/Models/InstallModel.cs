using System.ComponentModel.DataAnnotations;

namespace uBlog.Web.Models
{
    public class InstallModel
    {
        [Required]
        public string BlogTitle { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}