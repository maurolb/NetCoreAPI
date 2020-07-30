using MyDrawGallery.Core.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDrawGallery.Core.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUser(int userId);
    }
}
