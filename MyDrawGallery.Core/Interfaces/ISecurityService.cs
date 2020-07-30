using MyDrawGallery.Core.Entitites;
using System.Threading.Tasks;

namespace MyDrawGallery.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginCredentials(UserLogin userlogin);
        Task RegisterUser(Security security);
    }
}