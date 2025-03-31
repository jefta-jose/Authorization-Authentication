namespace api.Models
{
    public class Password
    {
        public string ResetToken { get; set; } = "";
        public DateTime? ResetDateExpiry { get; set; }
        public User? User { get; set; }
    }
}
