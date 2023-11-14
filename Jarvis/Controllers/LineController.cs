using Jarvis.Enums;
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
    public async Task<ApiResponse> Notify(WebHookEventRequest request)
    {
        request.Events.ForEach(async e =>
        {
            await _botService.Notify(e);
        });

        return ApiResponse.SuccessWithData("OK");
    }

    // GET
    [HttpGet("health")]
    public string Health()
    {
        return "OK";
    }
}