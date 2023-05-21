using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services;

public class BotService : IBotService
{
    private readonly IEventHandleService _eventHandleService;

    public BotService(IEventHandleService eventHandleService)
    {
        _eventHandleService = eventHandleService;
    }

    public async Task NotifyHandling(List<BotEvent> botEvents)
    {
        foreach (var e in botEvents)
        {
            await _eventHandleService.Handle(e);
        }
    }

   
}