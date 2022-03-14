using Newtonsoft.Json;
using System.Collections.Generic;

namespace News.Models
{
    internal class NewsResponse
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("articles")] public IEnumerable<New> News { get; set; }
    }
}
