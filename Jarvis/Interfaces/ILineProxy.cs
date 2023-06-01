using Jarvis.Models;
using Jarvis.Services;

namespace Jarvis.Interfaces;

public interface ILineProxy
{
    Task ReplayMessage(string messageToReply, BotEventDto botEventDto);
    Task<UserProfile> GetUserProfile(BotEventDto botEventDto);
}