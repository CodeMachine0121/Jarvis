using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.EventHandlingServices;

public class FollowService: IEventService
{
    private readonly ILineProxy _lineProxy;
    private readonly IEventService _eventService;

    public FollowService(ILineProxy lineProxy, IEventService eventService)
    {
        _lineProxy = lineProxy;
        _eventService = eventService;
    }

    public async Task Handle(BotEventDto botEventDto)
    {
        if (botEventDto.IsFollowEvent())
        {
            var user = await _lineProxy.GetUserProfile(botEventDto);
            await _lineProxy.ReplayMessage($"Welcome，{user.displayName}",botEventDto);
            return;
        }
        await _eventService.Handle(botEventDto);
    }
}