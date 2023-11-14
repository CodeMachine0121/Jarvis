using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.EventHandlingServices;

public class MessageService: IEventService
{
    private readonly ILineProxy _lineProxy;

    public MessageService(ILineProxy lineProxy)
    {
        _lineProxy = lineProxy;
    }

    public async Task Handle(BotEventDto botEventDto)
    {
        if (botEventDto.IsMessageEvent())
        {
            var responseText = "reply: "+ botEventDto.Message.text; 
            await _lineProxy.ReplayMessage(responseText, botEventDto);
        }
    }
}