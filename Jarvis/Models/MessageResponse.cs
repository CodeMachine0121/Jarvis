namespace Jarvis.Models;

public class MessageResponse
{
    public MessageResponse(string replyToken)
    {
        this.replyToken = replyToken;
    }

    public string replyToken { get; set; }
    public List<Message> messages { get; set; } = new List<Message>();
}