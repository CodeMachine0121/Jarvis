using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.EventHandlingServices;

public class UnfollowHandleService : IEventHandleService
{
    private readonly IEventHandleService _eventHandleService;

    public UnfollowHandleService(IEventHandleService eventHandleService)
    {
        _eventHandleService = eventHandleService;
    }

    public async Task Handle(BotEventDto botEventDto)
    {
        if (botEventDto.Type.ToLower() ==EventType.unfollow.ToString())
        {

            return;
        }

        await _eventHandleService.Handle(botEventDto);
    }
}