using MyDrawGallery.Core.Enumerations;

namespace MyDrawGallery.Core.Entitites
{
    public class Security : BaseEntity
    {
        public string User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
    }
}
