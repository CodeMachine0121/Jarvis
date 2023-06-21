using System.Net;
using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.Handlers;

public abstract class EventHandler
{
    protected EventHandler _eventHandler;
    protected ILineProxy _lineProxy;

    public void SetHandler(EventHandler eventHandler, ILineProxy lineProxy)
    {
        _eventHandler = eventHandler;
        _lineProxy = lineProxy;
    }

    public abstract Task<HttpStatusCode> HandleEvent(BotEventDto dto);

    protected bool IsHandlerNull()
    {
        return _eventHandler.Equals(null);
    }

}