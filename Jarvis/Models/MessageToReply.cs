using Jarvis.Enums;
using Microsoft.OpenApi.Extensions;

namespace Jarvis.Models;

public class MessageToReply : Message
{
    public string type => MessageType.text.GetDisplayName();
    public string text { get; set; }
}