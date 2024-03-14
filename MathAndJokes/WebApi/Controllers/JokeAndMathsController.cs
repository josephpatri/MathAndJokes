using Microsoft.AspNetCore.Mvc;
using Application.Features.Queries;
using Swashbuckle.AspNetCore.Annotations;
using Application.DTOs;
using System.Threading.Tasks;
using Application.Features.Commands;

namespace WebApi.Controllers
{
    public class JokeAndMathsController : BaseController
    {
        /// <summary>
        /// Retrieve a joke with an optional parameter. This endpoint allows retrieving a joke. If an optional parameter is provided, the joke retrieved may vary based on that parameter.
        /// </summary>
        /// <param name="param">string ("Dad", "Chuck"), can be empty</param>
        /// <returns>Returns a Joke!</returns>
        /// <response code="200">Returns the joke</response>
        /// <response code="400">If the param is null</response>
        [HttpGet]
        public async Task<IActionResult> GetAJoke([FromQuery]string? param = null)
        {
            return Ok(await Mediator.Send(new GetJokeWithOptionalParam { param = param }));
        }


        [HttpPost]
        public async Task<IActionResult> CreateAJoke(CreateJokes command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
