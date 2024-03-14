using Application.DTOs;
using Application.Features.Commands;
using Application.Features.Queries;
using Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace WebApi.Tests
{
    public class JokesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly JokesController _controller;

        public JokesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = GetJokesControllerWithMockedMediator();
        }

        private JokesController GetJokesControllerWithMockedMediator()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient(_ => _mediatorMock.Object)
                .BuildServiceProvider();

            return new JokesController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { RequestServices = serviceProvider }
                }
            };
        }

        private void SetupMediatorToSendResponse<T>(Response<T> response)
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<IRequest<Response<T>>>(), default)).ReturnsAsync(response);
        }

        [Fact]
        public async Task GetAJoke_ReturnsOkWithJokeDto_WhenParamIsNull()
        {
            // Arrange
            var expectedJokeDto = new JokeDto { Id = "1", JokeName = "Joke from DadJokes", JokeDescription = "Test joke" };
            SetupMediatorToSendResponse(new Response<JokeDto>(expectedJokeDto));

            // Act
            var result = await _controller.GetAJoke();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseDto = Assert.IsType<Response<JokeDto>>(okResult.Value);
            var jokeDto = responseDto.Data;
            Assert.Equal(expectedJokeDto.Id, jokeDto.Id);
            Assert.Equal(expectedJokeDto.JokeName, jokeDto.JokeName);
            Assert.Equal(expectedJokeDto.JokeDescription, jokeDto.JokeDescription);
        }

        [Theory]
        [InlineData("Chuck", "Joke from Chuck!", "Test joke from Chuck!")]
        [InlineData("Dad", "Joke from DadJokes", "Dad joke")]
        public async Task GetAJoke_ReturnsOkWithCorrectJokeDto_WhenParamIsValid(string param, string expectedName, string expectedDescription)
        {
            // Arrange
            var expectedJokeDto = new JokeDto { Id = "1", JokeName = expectedName, JokeDescription = expectedDescription };
            SetupMediatorToSendResponse(new Response<JokeDto>(expectedJokeDto));

            // Act
            var result = await _controller.GetAJoke(param);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseDto = Assert.IsType<Response<JokeDto>>(okResult.Value);
            var jokeDto = responseDto.Data;
            Assert.Equal(expectedJokeDto.Id, jokeDto.Id);
            Assert.Equal(expectedJokeDto.JokeName, jokeDto.JokeName);
            Assert.Equal(expectedJokeDto.JokeDescription, jokeDto.JokeDescription);
        }

        [Fact]
        public async Task GetAJoke_ReturnsKeyNotFoundException_WhenParamIsInvalid()
        {
            // Arrange
            var invalidParam = "InvalidParam";
            var expectedMessage = "That type of joke does not exist";
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetJokeWithOptionalParam>(), default))
                .ThrowsAsync(new KeyNotFoundException(expectedMessage));

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _controller.GetAJoke(invalidParam));
        }

        [Fact]
        public async Task CreateAJoke_ReturnsOkWithNewJokeId_WhenJokeIsValid()
        {
            // Arrange
            var command = new CreateJokes
            {
                JokeName = "Test Joke",
                JokeDescription = "This is a test joke description.",
                JokeOwner = "Test Owner"
            };
            var expectedResponse = new Response<int>(1, "Joke created successfully");
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateJokes>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.CreateAJoke(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Response<int>>(okResult.Value);
            Assert.Equal(expectedResponse.Data, returnValue.Data);
        }

        [Fact]
        public async Task UpdateAJoke_ReturnsOkWithUpdatedJokeId_WhenJokeIsValid()
        {
            // Arrange
            var command = new UpdateJokes
            {
                Id = 1,
                JokeName = "Test Joke",
                JokeDescription = "This is a test joke description.",
                JokeOwner = "Test Owner"
            };
            var expectedResponse = new Response<int>(1, "Joke updated successfully");
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateJokes>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.UpdateAJoke(command.Id, command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Response<int>>(okResult.Value);
            Assert.Equal(expectedResponse.Data, returnValue.Data);
        }

        [Fact]
        public async Task DeleteAJoke_ReturnsOkWithDeletedJokeId_WhenJokeIsValid()
        {
            // Arrange
            var command = new DeleteJokes
            {
                Id = 1
            };
            var expectedResponse = new Response<int>(1, "Joke deleted successfully");
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteJokes>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.DeleteAJoke(command.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Response<int>>(okResult.Value);
            Assert.Equal(expectedResponse.Data, returnValue.Data);
        }

    }
}
