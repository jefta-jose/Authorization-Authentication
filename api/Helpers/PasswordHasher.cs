
namespace api.Helpers
{
    public static class PasswordHasher
    {
        private const int WorkFactor = 12;

        public static string HashPassword(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password, workFactor: WorkFactor);
        }

        public static bool VerifyPassword(string Password, string HashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(Password, HashedPassword);
        }
    }
}
