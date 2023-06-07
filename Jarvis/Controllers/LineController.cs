using System.Net;
using Jarvis.Interfaces;
using Jarvis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jarvis.Controllers;

[ApiController]
[Route("api")]
public class LineController : ControllerBase 
{
    private readonly IBotService _botService;

    public LineController(IBotService botService)
    {
        _botService = botService;
    }
    
    [HttpPost("Notify")]
    public async Task<IActionResult> Notify( WebHookEventRequest request)
    {
        await _botService.NotifyHandling(request.Events.ToList());
        return Ok(request);
    }

    // GET
    [HttpGet("health")]
    public string Health()
    {
        return "OK";
    }
}