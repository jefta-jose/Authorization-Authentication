using api.DTOs;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        [Required]
        [EmailAddress(ErrorMessage = "Email Address Required")]
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = "";

        public DateTime CreatedDate = DateTime.UtcNow;
    }
}
