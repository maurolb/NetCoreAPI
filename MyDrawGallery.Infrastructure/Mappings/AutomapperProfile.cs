using AutoMapper;
using MyDrawGallery.Core.DTOs;
using MyDrawGallery.Core.Entitites;

namespace MyDrawGallery.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<Security, SecurityDto>();
            CreateMap<SecurityDto, Security>();
        }
    }
}
