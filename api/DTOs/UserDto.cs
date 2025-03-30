namespace api.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = "";

        public string Role { get; set; } = "";
    }
}
