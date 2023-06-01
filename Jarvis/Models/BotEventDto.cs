namespace Jarvis.Models;

public class BotEventDto
{
    public string Type { get; set; }
    public Message Message { get; set; }
    public Source Source { get; set; }
    public string ReplyToken { get; set; }

}