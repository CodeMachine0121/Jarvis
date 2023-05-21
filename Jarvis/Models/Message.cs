using Jarvis.Enums;
using Newtonsoft.Json;

namespace Jarvis.Models;

public class Message
{
    public string type { get; set; }
    public string id { get; set; }
    public string text { get; set; }
}