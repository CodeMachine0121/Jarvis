using Jarvis.Interfaces;
using Jarvis.Models;
using Jarvis.Services.Handlers;

namespace Jarvis.Services;

public class BotService : IBotService
{
    private readonly HandlerSetting _handleSetting;

    public BotService(HandlerSetting handleSetting)
    {
        _handleSetting = handleSetting;
        _handleSetting.Set();
    }

    public async Task NotifyHandling(IEnumerable<BotEvent> botEvents)
    {
        foreach (var e in botEvents)
        {
            await _handleSetting.Start(e.ToBotEventDto());
        }
    }
}