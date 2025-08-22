using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MedGestor.Adapter.Driving.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "ApiKeyPolicy")] 
public class TesteController : ControllerBase
{
    [HttpGet]
    [Route("Ping")]
    [ProducesResponseType(typeof(Ok<string>), StatusCodes.Status200OK)]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }
}