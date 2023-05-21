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

    public async Task Handle(BotEvent botEvent)
    {
        await _eventHandleService.Handle(botEvent);
    }
}