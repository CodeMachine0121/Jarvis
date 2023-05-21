using Jarvis.Enums;

namespace Jarvis.Models;

public class BotEvent
{
    public EventType Type;
    public Source source;
    public string replyToken;
    public Message Message { get; set; }
    public string Mode { get; set; }
    public string WebhookEventId { get; set; }
}