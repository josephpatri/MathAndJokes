using Application.Features.Commands;
using Application.Features.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class JokesController : BaseController
    {
        /// <summary>
        /// Get a new joke from internet
        /// </summary>
        /// <remarks>
        /// Retrieve a joke with an optional parameter. This endpoint allows retrieving a joke. If an optional parameter is provided, the joke retrieved may vary based on that parameter.
        /// </remarks>
        /// <param name="param">string ("Dad", "Chuck"), can be empty</param>
        /// <returns>Returns a Joke!</returns>
        /// <response code="200">Returns the joke</response>
        /// <response code="400">If the param is null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAJoke([FromQuery]string? param = null)
        {
            return Ok(await Mediator.Send(new GetJokeWithOptionalParam { param = param }));
        }

        /// <summary>
        /// Creates a new joke in the system.
        /// </summary>
        /// <remarks>
        /// This endpoint allows clients to create a new joke by providing its name, description, and owner.
        /// </remarks>
        /// <param name="command">The joke creation command containing the name, description, and owner of the joke.</param>
        /// <returns>A response containing the ID of the newly created joke.</returns>
        /// <response code="200">Returns the ID of the newly created joke.</response>
        /// <response code="400">If the request is bad or validation fails.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAJoke(CreateJokes command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing joke in the system.
        /// </summary>
        /// <remarks>
        /// This endpoint allows clients to update an existing joke by providing its ID along with the updated content such as name, description, and owner.
        /// </remarks>
        /// <param name="Id">The ID of the joke to be updated.</param>
        /// <param name="command">The command containing the updated content for the joke.</param>
        /// <returns>A response indicating the success of the update operation.</returns>
        /// <response code="200">Returns a success message indicating the joke was updated successfully.</response>
        /// <response code="400">If the request is bad or validation fails.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAJoke([FromQuery] int Id, [FromBody] UpdateJokes command)
        {
            if (Id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes an existing joke from the system.
        /// </summary>
        /// <remarks>
        /// This endpoint allows clients to delete an existing joke by providing its ID.
        /// </remarks>
        /// <param name="Id">The ID of the joke to be deleted.</param>
        /// <returns>A response indicating the success of the delete operation.</returns>
        /// <response code="200">Returns a success message indicating the joke was deleted successfully.</response>
        /// <response code="400">If the request is bad or validation fails.</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAJoke([FromQuery] int Id)
        {
            return Ok(await Mediator.Send(new DeleteJokes { Id = Id }));
        }
    }
}
