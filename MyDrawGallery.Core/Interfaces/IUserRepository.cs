using MyDrawGallery.Core.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDrawGallery.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}