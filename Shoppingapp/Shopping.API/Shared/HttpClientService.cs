using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace Shopping.API.Shared
{
    public class HttpClientService
    {
        public HttpClientService() 
        {
        }

        public async Task<T> SendPostRequestInternal<T, U>(PostRequest<U> request)
        {
            var accessToken = await _httpContext?.HttpContext?.GetAccessToken();
            var correlationId = _httpContext?.HttpContext.Items["correlationId"]?.ToString() ?? "";

            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(request.Url);
            message.Method = HttpMethod.Post;
            var data = JsonConvert.SerializeObject(request.Data);
            message.Content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            content = encryption.DecryptResponse(content, "internal");
            // _logger.LogInformation("Response from {Url} is {response}", message.RequestUri, content);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
