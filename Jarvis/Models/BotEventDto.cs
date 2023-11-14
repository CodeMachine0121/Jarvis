using Jarvis.Enums;

namespace Jarvis.Models;

public class BotEventDto
{
    public string Type { get; set; }
    public Message Message { get; set; }
    public Source Source { get; set; }
    public string ReplyToken { get; set; }

    public bool IsUnfollowEvent()
    {
        return Type.ToLower() ==EventType.unfollow.ToString();
    }

    public bool IsMessageEvent()
    {
        return Type.ToLower() == EventType.message.ToString();
    }

    public bool IsFollowEvent()
    {
        return Type.ToLower().Equals(EventType.follow.ToString());
    }
}