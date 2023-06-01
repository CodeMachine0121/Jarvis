using System.Net;
using Jarvis.Interfaces;
using Jarvis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jarvis.Controllers;

[ApiController]
public class LineController : ControllerBase 
{
    private readonly IBotService _botService;

    public LineController(IBotService botService)
    {
        _botService = botService;
    }
    
    [HttpPost("api/Notify")]
    public async Task<IActionResult> Notify( WebHookEventRequest request)
    {
        await _botService.NotifyHandling(request.Events.ToList());
        return Ok(request);
    }

    // GET
    [HttpGet("api/health")]
    public string Health()
    {
        return "OK";
    }
}