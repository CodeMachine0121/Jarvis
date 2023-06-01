using Jarvis.Enums;
using Newtonsoft.Json;

namespace Jarvis.Models;

public class BotEvent
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("message")]
    public Message Message { get; set; }
    
    [JsonProperty("webhookEventId")]
    public string WebhookEventId { get; set; }

    [JsonProperty("deliveryContext")]
    public DeliveryContext DeliveryContext { get; set; }
 
    
    [JsonProperty("source")]
    public Source Source{ get; set; }
    
    [JsonProperty("replyToken")]
    public string ReplyToken{ get; set; }
    
    
    [JsonProperty("mode")]
    public string Mode { get; set; }

    public BotEventDto ToBotEventDto()
    {
        return new BotEventDto()
        {
            Type = Type,
            Message = Message,
            Source = Source,
            ReplyToken = ReplyToken,
        };
    }
}