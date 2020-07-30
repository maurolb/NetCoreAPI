using MyDrawGallery.Core.Entitites;
using System.Threading.Tasks;

namespace MyDrawGallery.Core.Interfaces
{
    public interface ISecurityRepository: IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}