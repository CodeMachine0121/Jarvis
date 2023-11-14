using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.EventHandlingServices;

public class UnfollowService : IEventService
{
    private readonly IEventService _eventService;

    public UnfollowService(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task Handle(BotEventDto botEventDto)
    {
        if (botEventDto.IsUnfollowEvent())
        {
            return;
        }

        await _eventService.Handle(botEventDto);
    }
}