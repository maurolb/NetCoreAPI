using MyDrawGallery.Core.QueryFilters;
using System;

namespace MyDrawGallery.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}