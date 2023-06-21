using System.Net;
using Jarvis.Enums;
using Jarvis.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Jarvis.Services.Handlers;

public class FollowHandler : EventHandler
{
    public override async Task<HttpStatusCode> HandleEvent(BotEventDto dto)
    {
        if (dto.Type.ToLower().Equals(EventType.follow.ToString()))
        {
            var user = await _lineProxy.GetUserProfile(dto);
            return await _lineProxy.ReplayMessage($"Welcome，{user.displayName}", dto);
        }

        if (!IsHandlerNull())
        {
            return await _eventHandler.HandleEvent(dto);
        }

        return HttpStatusCode.OK;

    }
}