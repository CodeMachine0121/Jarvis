using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services;

public class BotService : IBotService
{
    private readonly IEventService _eventService;

    public BotService(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task Notify(BotEvent botEvent)
    {
        await _eventService.Handle(botEvent.ToBotEventDto());
    }
}