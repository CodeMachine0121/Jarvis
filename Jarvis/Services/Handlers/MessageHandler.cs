using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.Handlers;

public class MessageHandler : EventHandler
{
    public override async Task HandleEvent(BotEventDto dto)
    {
        if (dto.Type.ToLower() == EventType.message.ToString())
        {
            var responseText = "reply: "+ dto.Message.text; 
            await _lineProxy.ReplayMessage(responseText, dto);
        }
        
        if (!IsHandlerNull())
        {
            await _eventHandler.HandleEvent(dto);
        }
    }

}