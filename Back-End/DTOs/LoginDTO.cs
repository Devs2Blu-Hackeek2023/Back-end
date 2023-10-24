namespace Back_End.DTOs
{
    public class LoginDTO
    {
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
