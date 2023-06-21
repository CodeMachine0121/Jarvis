using System.Net;
using Jarvis.Enums;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.Handlers;

public class MessageHandler : EventHandler
{
    public override async Task<HttpStatusCode> HandleEvent(BotEventDto dto)
    {
        if (dto.Type.ToLower() == EventType.message.ToString())
        {
            var responseText = "reply: "+ dto.Message.text;
            return await _lineProxy.ReplayMessage(responseText, dto);
        }
        
        if (!IsHandlerNull())
        {
            return await _eventHandler.HandleEvent(dto);
        }

        return HttpStatusCode.OK;
    }

}