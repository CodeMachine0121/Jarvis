using Jarvis.Models;

namespace Jarvis.Interfaces;

public interface IEventService
{
    Task Handle(BotEventDto botEventDto);
}