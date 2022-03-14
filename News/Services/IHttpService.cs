using System.Threading.Tasks;

namespace News.Services
{
    internal interface IHttpService
    {
        Task<byte[]> GetAsync(string url);
    }
}
