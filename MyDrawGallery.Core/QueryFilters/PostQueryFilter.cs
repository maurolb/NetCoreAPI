using System;

namespace MyDrawGallery.Core.QueryFilters
{
    public class PostQueryFilter
    {
        public int? userId { get; set; }
        public DateTime? date { get; set; }
        public string description { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
