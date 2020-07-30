using MyDrawGallery.Core.Entitites;

namespace MyDrawGallery.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Metadata meta { get; set; }
    }
}
