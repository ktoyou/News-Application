using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace News.Models
{
    internal class NewsResponse : BaseResponse
    {
        [JsonProperty("articles")] public IEnumerable<New> News { get; set; }
    }
}
