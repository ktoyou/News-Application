using News.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace News.Services
{
    internal class NewsService : INewsService
    {
        public NewsService(IHttpService httpService, string apiKey)
        {
            _apiKey = apiKey;
            _httpService = httpService;
        }

        public async Task<NewsResponse> GetNewsAsync(string keyword)
        {
            string url = $"https://newsapi.org/v2/everything?q={keyword}&apiKey={_apiKey}";
            byte[] buffer = await _httpService.GetAsync(url);
            string encodedJson = Encoding.UTF8.GetString(buffer);
            
            return JsonConvert.DeserializeObject<NewsResponse>(encodedJson);
        }

        private readonly string _apiKey;

        private IHttpService _httpService;
    }
}
