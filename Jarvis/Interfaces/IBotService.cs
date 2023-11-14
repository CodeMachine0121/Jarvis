using Jarvis.Enums;
using Jarvis.Models;

namespace Jarvis.Interfaces;

public interface IBotService
{
    Task Notify(BotEvent botEvent);
}