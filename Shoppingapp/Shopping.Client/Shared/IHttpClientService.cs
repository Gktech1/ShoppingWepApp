

using Shopping.Client.Dtos;

namespace Shopping.Client.Shared
{
    public interface IHttpClientService
    {
        Task<T> SendGetRequest<T>(GetRequest request);
    }
}
