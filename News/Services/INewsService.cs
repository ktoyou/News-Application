using News.Models;
using System.Threading.Tasks;

namespace News.Services
{
    internal interface INewsService
    {
        Task<NewsResponse> GetNewsAsync(string keyword);
    }
}
