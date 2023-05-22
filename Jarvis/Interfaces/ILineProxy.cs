using Jarvis.Models;
using Jarvis.Services;

namespace Jarvis.Interfaces;

public interface ILineProxy
{
    Task ReplayMessage(string messageToReply, BotEvent botEvent);
    Task<UserProfile> GetUserProfile(BotEvent botEvent);
}