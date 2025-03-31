using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class CreateUserDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        [Required]
        [EmailAddress(ErrorMessage = "Email Address Required")]
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
