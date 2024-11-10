namespace HotelWebApp.Models
{
    public class UserRegistrationDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserName { get; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
    }
}
