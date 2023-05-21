using Newtonsoft.Json;

namespace Jarvis.Models;

public class DeliveryContext
{
    [JsonProperty("isRedelivery")]
    public bool IsRedelivery { get; set; }
}