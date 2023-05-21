using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.EventHandlingServices;

public class MessageHandleService: IEventHandleService
{
    private readonly ILineProxy _lineProxy;

    public MessageHandleService(ILineProxy lineProxy)
    {
        _lineProxy = lineProxy;
    }

    public async Task Handle(BotEvent botEvent)
    {
        if (botEvent.Type.ToLower() == EventType.message.ToString())
        {
            var responseText = "reply: "+ botEvent.Message.text; 
            await _lineProxy.ReplayMessage(responseText, botEvent.ReplyToken); 
        }
        return;
    }
}