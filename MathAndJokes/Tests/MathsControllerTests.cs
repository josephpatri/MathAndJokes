using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace WebApi.Tests
{
    public class MathsControllerTests
    {
        private readonly Mock<MathCalcs> _mockService;
        private readonly MathsController _controller;

        public MathsControllerTests()
        {
            _mockService = new Mock<MathCalcs>();
            _controller = new MathsController(_mockService.Object);
        }

        [Fact]
        public void GetLCM_ReturnsBadRequest_WhenNoNumbersProvided()
        {
            // Act
            var result = _controller.GetLCM(string.Empty);

            // Assert
            var badRequestResult = Assert.IsAssignableFrom<ActionResult<int>>(result);
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
            Assert.Equal("No numbers provided.", ((BadRequestObjectResult)badRequestResult.Result).Value);
        }

        [Fact]
        public void GetLCM_ReturnsBadRequest_WhenInvalidNumberProvided()
        {
            // Act
            var result = _controller.GetLCM("1,2,abc");

            // Assert
            var badRequestResult = Assert.IsAssignableFrom<ActionResult<int>>(result);
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
            Assert.Equal("Invalid number: abc", ((BadRequestObjectResult)badRequestResult.Result).Value);
        }

        [Fact]
        public void GetLCM_Returns_CorrectLCM()
        {
            // Arrange
            var numbers = "2,3,5";

            // Act
            var result = _controller.GetLCM(numbers);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(30, okResult.Value);
        }

        [Fact]
        public void IncrementNumber_ReturnsIncrementedNumber()
        {
            // Arrange

            // Act
            var result = _controller.IncrementNumber(5);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(6, okResult.Value);
        }
    }
}
