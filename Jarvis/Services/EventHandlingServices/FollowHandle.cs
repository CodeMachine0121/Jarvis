using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.EventHandlingServices;

public class FollowHandleService: IEventHandleService
{
    private readonly ILineProxy _lineProxy;
    private readonly IEventHandleService _eventService;

    public FollowHandleService(ILineProxy lineProxy, IEventHandleService eventService)
    {
        _lineProxy = lineProxy;
        _eventService = eventService;
    }

    public async Task Handle(BotEvent botEvent)
    {
        if (botEvent.Type.ToLower() == EventType.follow.ToString())
        {
            var user = await _lineProxy.GetUserProfile(botEvent);
            await _lineProxy.ReplayMessage($"Welcome，{user.displayName}",botEvent);
            return;
        }
        await _eventService.Handle(botEvent);
    }
}