using System.ComponentModel;

namespace Jarvis.Enums;

public enum EventType
{
    [Description("message")]
    message,
    [Description("follow")]
    follow,
    [Description("unfloow")]
    unfollow
}