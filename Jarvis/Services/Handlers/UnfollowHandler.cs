using Jarvis.Enums;
using Jarvis.Models;

namespace Jarvis.Services.Handlers;

public class UnfollowHandler : EventHandler
{
    public override async Task HandleEvent(BotEventDto dto)
    {
        if (dto.Type.ToLower() == EventType.unfollow.ToString())
        { }

        if (!IsHandlerNull())
        {
            await _eventHandler.HandleEvent(dto);
        }
    }
}