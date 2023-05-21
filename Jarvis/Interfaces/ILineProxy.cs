using Jarvis.Models;
using Jarvis.Services;

namespace Jarvis.Interfaces;

public interface ILineProxy
{
    Task ReplayMessage(string messageToReply, string replyToken);
    Task<UserProfile> GetUserProfile(BotEvent botEvent);
}