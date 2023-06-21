using System.Net;
using Jarvis.Enums;
using Jarvis.Models;

namespace Jarvis.Services.Handlers;

public class UnfollowHandler : EventHandler
{
    public override async Task<HttpStatusCode> HandleEvent(BotEventDto dto)
    {
        if (dto.Type.ToLower() == EventType.unfollow.ToString())
        {
        }
        

        if (!IsHandlerNull())
        {
            return await _eventHandler.HandleEvent(dto);
        }

        return HttpStatusCode.OK;
    }
}