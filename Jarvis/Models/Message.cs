using Jarvis.Enums;

namespace Jarvis.Models;

public class Message
{
    public MessageType type { get; set; }
    
    public string id { get; set; }
    public string text { get; set; }
}