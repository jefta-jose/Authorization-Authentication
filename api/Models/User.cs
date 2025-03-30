using api.DTOs;

namespace api.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = "";

        public string Role { get; set; } = "";

        public static implicit operator User(UserDto v)
        {
            throw new NotImplementedException();
        }
    }
}
