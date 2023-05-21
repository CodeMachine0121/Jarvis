using Microsoft.AspNetCore.Mvc;

namespace Jarvis.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LineController : Controller
{
    // GET
    [HttpGet("/health")]
    public string health()
    {
        return "OK";
    }
}