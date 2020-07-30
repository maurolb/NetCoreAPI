using Microsoft.Extensions.Options;
using MyDrawGallery.Core.Entitites;
using MyDrawGallery.Core.Exceptions;
using MyDrawGallery.Core.Interfaces;
using MyDrawGallery.Core.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyDrawGallery.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public PostService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Post> GetPosts(PostQueryFilter filters)
        {
            filters.pageNumber = filters.pageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.pageNumber;
            filters.pageSize = filters.pageSize == 0 ? _paginationOptions.DefaultPageSize : filters.pageSize;

            var posts = _unitOfWork.PostRepository.GetAll();

            if(filters.userId != null)
            {
                posts = posts.Where(x => x.UserId == filters.userId);
            }
            if (filters.date != null)
            {
                posts = posts.Where(x => x.Date.ToShortDateString() == filters.date?.ToShortDateString());
            }
            if (filters.description != null)
            {
                posts = posts.Where(x => x.Description.ToLower().Contains(filters.description.ToLower()));
            }

            var pagedPosts = PagedList<Post>.Create(posts, filters.pageNumber, filters.pageSize);
            return pagedPosts;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if(user == null)
            {
                throw new BusinessException("User doesn't exist");
            }
            var userPost = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if(userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x=> x.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessException("You are no able to publish the post");
                }
            }

            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var existingPost = await _unitOfWork.PostRepository.GetById(post.Id);
            existingPost.Image = post.Image;
            existingPost.Description = post.Description;

            _unitOfWork.PostRepository.Update(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
