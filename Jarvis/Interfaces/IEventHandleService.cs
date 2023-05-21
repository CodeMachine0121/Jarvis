using Jarvis.Models;

namespace Jarvis.Interfaces;

public interface IEventHandleService
{
    Task Handle(BotEvent botEvent);
}