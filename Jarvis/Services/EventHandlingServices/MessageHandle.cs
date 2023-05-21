using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.EventHandlingServices;

public class MessageHandleService: IEventHandleService
{
    private readonly IEventHandleService _handleService;
    private ILineProxy _lineProxy;

    public MessageHandleService(IEventHandleService handleService, ILineProxy lineProxy)
    {
        _handleService = handleService;
        _lineProxy = lineProxy;
    }

    public async Task Handle(BotEvent botEvent)
    {
        var responseText = "reply: "+ botEvent.Message.text; 
         await _lineProxy.ReplayMessage(responseText, botEvent.replyToken); 
    }
}