using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MathsController : ControllerBase
    {
        private readonly MathCalcs _service;
        public MathsController(MathCalcs service)
        {
            _service = service;
        }

        /// <summary>
        /// Calculates the Least Common Multiple (LCM) of a list of integers.
        /// </summary>
        /// <remarks>
        /// This endpoint calculates the LCM of a list of integers provided as a query parameter.
        /// </remarks>
        /// <param name="numbers">A comma-separated list of integers.</param>
        /// <returns>The calculated LCM.</returns>
        /// <response code="200">Returns the calculated LCM.</response>
        /// <response code="400">If no numbers are provided or if an invalid number is encountered.</response>
        [HttpGet("lcm")]
        public ActionResult<int> GetLCM([FromQuery] string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return BadRequest("No numbers provided.");
            }

            // Parse the numbers from the zquery string
            string[] numberStrings = numbers.Split(',');
            List<int> numberList = new List<int>();
            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString, out int parsedNumber))
                {
                    numberList.Add(parsedNumber);
                }
                else
                {
                    return BadRequest($"Invalid number: {numberString}");
                }
            }

            int lcm = _service.CalculateLCM(numberList);
            return Ok(lcm);
        }

        /// <summary>
        /// Increments a given number by 1.
        /// </summary>
        /// <remarks>
        /// This endpoint increments a given integer by 1.
        /// </remarks>
        /// <param name="number">The number to increment.</param>
        /// <returns>The incremented number.</returns>
        /// <response code="200">Returns the incremented number.</response>
        [HttpGet("increment")]
        public ActionResult<int> IncrementNumber([FromQuery] int number)
        {
            int result = number + 1;
            return Ok(result);
        }        
    }
}
