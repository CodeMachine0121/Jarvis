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
        var response = await _botService.NotifyHandling(request.Events.ToList());

        var returnResult = response.Any()
            ? response.Any(e => e == ApiStatus.Error)
                ? StatusCodes.Status417ExpectationFailed
                : StatusCodes.Status200OK
            : StatusCodes.Status417ExpectationFailed;

        return ApiResponse.SuccessWithData(returnResult);
    }

    // GET
    [HttpGet("health")]
    public string Health()
    {
        return "OK";
    }
}