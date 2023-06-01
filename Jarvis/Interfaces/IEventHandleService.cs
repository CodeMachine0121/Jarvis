using Jarvis.Models;

namespace Jarvis.Interfaces;

public interface IEventHandleService
{
    Task Handle(BotEventDto botEventDto);
}