using System.Net;
using Jarvis.Models;
using Jarvis.Services;

namespace Jarvis.Interfaces;

public interface ILineProxy
{
    Task<HttpStatusCode> ReplayMessage(string messageToReply, BotEventDto botEventDto);
    Task<UserProfile> GetUserProfile(BotEventDto botEventDto);
}