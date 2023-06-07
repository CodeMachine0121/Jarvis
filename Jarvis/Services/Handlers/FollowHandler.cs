using Jarvis.Enums;
using Jarvis.Models;

namespace Jarvis.Services.Handlers;

public class FollowHandler : EventHandler
{
    public override async Task HandleEvent(BotEventDto dto)
    {
        if (dto.Type.ToLower().Equals(EventType.follow.ToString()))
        {
            var user = await _lineProxy.GetUserProfile(dto);
            await _lineProxy.ReplayMessage($"Welcome，{user.displayName}", dto);
        }

        if (!IsHandlerNull())
        {
            await _eventHandler.HandleEvent(dto);
        }
    }
}