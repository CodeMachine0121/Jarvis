using Jarvis.Enums;
using Jarvis.Models;

namespace Jarvis.Interfaces;

public interface IBotService
{
    Task<List<ApiStatus>> NotifyHandling(List<BotEvent> botEvents);
}