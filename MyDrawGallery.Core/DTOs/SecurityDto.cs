using MyDrawGallery.Core.Enumerations;

namespace MyDrawGallery.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
