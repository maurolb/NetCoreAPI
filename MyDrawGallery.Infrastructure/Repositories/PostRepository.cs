using Microsoft.EntityFrameworkCore;
using MyDrawGallery.Core.Entitites;
using MyDrawGallery.Core.Interfaces;
using MyDrawGallery.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDrawGallery.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(MyDrawGalleryContext context) : base(context){}

        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
