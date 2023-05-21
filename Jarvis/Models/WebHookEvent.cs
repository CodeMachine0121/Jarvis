using Newtonsoft.Json;

namespace Jarvis.Models;

public class WebHookEvent
{
    [JsonProperty("destination")]
    public string Destination { get; set; }
    
    [JsonProperty("events")] 
    public BotEvent[] Events { get; set; }
}