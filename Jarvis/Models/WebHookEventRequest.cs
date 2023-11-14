using Newtonsoft.Json;

namespace Jarvis.Models;

public class WebHookEventRequest
{
    [JsonProperty("destination")]
    public string Destination { get; set; }
    
    [JsonProperty("events")] 
    public List<BotEvent> Events { get; set; }
}