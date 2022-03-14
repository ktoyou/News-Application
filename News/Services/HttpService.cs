using System.Net.Http;
using System.Threading.Tasks;

namespace News.Services
{
    internal class HttpService : IHttpService
    {
        public async Task<byte[]> GetAsync(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
