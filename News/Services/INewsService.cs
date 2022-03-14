using News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Services
{
    internal interface INewsService
    {
        Task<BaseResponse> GetNewsAsync(string keyword);
    }
}
