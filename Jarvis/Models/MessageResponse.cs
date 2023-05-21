namespace Jarvis.Models;

public class MessageResponse
{
    public string replyToken { get; set; }
    public List<Message> messages { get; set; } = new List<Message>();

}