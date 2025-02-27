namespace users_wf.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Role { get; set; } = string.Empty;
    }
}
