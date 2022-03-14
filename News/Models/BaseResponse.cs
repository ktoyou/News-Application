using Newtonsoft.Json;

namespace News.Models
{
    internal class BaseResponse 
    {
        [JsonProperty("status")] public string Status { get; set; }
    }
}
