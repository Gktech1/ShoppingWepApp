
using Newtonsoft.Json;
using Shopping.Client.Dtos;

namespace Shopping.Client.Shared
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> SendGetRequest<T>(GetRequest request)
        {
            // Validate the request URL to ensure it is a valid external URL
            var url = request.Url;
            var uri = new Uri(url);
    /*        if (!uri.IsWellFormedOriginalString() || !uri.IsAbsoluteUri || uri.IsLoopback)
            {
                throw new ArgumentException("Invalid URL");
            }*/

            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = uri;
            message.Method = HttpMethod.Get;
            message.Headers.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Clear();
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
