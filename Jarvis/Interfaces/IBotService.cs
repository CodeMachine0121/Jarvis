using Jarvis.Models;

namespace Jarvis.Interfaces;

public interface IBotService
{
    Task NotifyHandling(List<BotEvent> botEvents);
}