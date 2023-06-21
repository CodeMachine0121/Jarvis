using System.Net;
using Jarvis.Enums;
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

    public async Task<List<ApiStatus>> NotifyHandling(List<BotEvent> botEvents)
    {
        var apiStatusList = new List<ApiStatus>();

        botEvents.ForEach(async e =>
        {
           apiStatusList.Add(await _handleSetting.Start(e.ToBotEventDto()));
        });

        return apiStatusList;
    }
}