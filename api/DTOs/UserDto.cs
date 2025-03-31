using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = "";

        public DateTime CreatedDate = DateTime.UtcNow;
    }
}
