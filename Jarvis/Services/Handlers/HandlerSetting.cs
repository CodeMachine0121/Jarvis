﻿using Jarvis.Interfaces;
using Jarvis.Models;

namespace Jarvis.Services.Handlers;

public class HandlerSetting
{
    private readonly FollowHandler _followHandler;
    private readonly ILineProxy _lineProxy;
    private readonly MessageHandler _messageHandler;
    private readonly UnfollowHandler _unfollowHandler;

    public HandlerSetting(MessageHandler messageHandler, FollowHandler followHandler, UnfollowHandler unfollowHandler, ILineProxy lineProxy)
    {
        _messageHandler = messageHandler;
        _followHandler = followHandler;
        _unfollowHandler = unfollowHandler;
        _lineProxy = lineProxy;
    }

    public void Set()
    {
        _messageHandler.SetHandler(_followHandler, _lineProxy);
        _followHandler.SetHandler(_unfollowHandler, _lineProxy);
    }

    public async Task Start(BotEventDto dto)
    {
        await _messageHandler.HandleEvent(dto);
    }
}