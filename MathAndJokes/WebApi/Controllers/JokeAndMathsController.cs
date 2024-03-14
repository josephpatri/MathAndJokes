using Microsoft.AspNetCore.Mvc;
using Application.Features.Queries;

namespace WebApi.Controllers;
    
public class JokeAndMathsController : BaseController
{
    [HttpGet("{param}")]
    public async Task<IActionResult> GetAJoke(string? param)
    {
        return Ok(await Mediator.Send(new GetJokeWithOptionalParam { param = param }));
    }
}
