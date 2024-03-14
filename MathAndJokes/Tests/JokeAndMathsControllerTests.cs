using Application.DTOs;
using Application.Features.Queries;
using Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Controllers
{
    public class JokeAndMathsControllerTests
    {
        [Fact]
        public async Task GetAJoke_ReturnsOkWithJokeDto_WhenParamIsNull()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var serviceProvider = new ServiceCollection()
                .AddTransient(_ => mediatorMock.Object)
                .BuildServiceProvider();
            var controller = new JokeAndMathsController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { RequestServices = serviceProvider }
                }
            };
            var expectedJokeDto = new JokeDto { Id = "1", JokeName = "Joke from DadJokes", JokeDescription = "Test joke" };
            var response = new Response<JokeDto>(expectedJokeDto);
            mediatorMock.Setup(x => x.Send(It.IsAny<GetJokeWithOptionalParam>(), default)).ReturnsAsync(response);

            // Act
            var result = await controller.GetAJoke();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseDto = Assert.IsType<Response<JokeDto>>(okResult.Value);
            var jokeDto = responseDto.Data;
            Assert.Equal(expectedJokeDto.Id, jokeDto.Id);
            Assert.Equal(expectedJokeDto.JokeName, jokeDto.JokeName);
            Assert.Equal(expectedJokeDto.JokeDescription, jokeDto.JokeDescription);
        }

        [Fact]
        public async Task GetAJoke_ReturnsOkWithJokeDtoFromChuck_WhenParamIsChuck()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var serviceProvider = new ServiceCollection()
                .AddTransient(_ => mediatorMock.Object)
                .BuildServiceProvider();
            var controller = new JokeAndMathsController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { RequestServices = serviceProvider }
                }
            };
            var expectedJokeDto = new JokeDto { Id = "1", JokeName = "Joke from Chuck!", JokeDescription = "Test joke from Chuck!" };
            var response = new Response<JokeDto>(expectedJokeDto);
            mediatorMock.Setup(x => x.Send(It.Is<GetJokeWithOptionalParam>(p => p.param == "Chuck"), default)).ReturnsAsync(response);

            // Act
            var result = await controller.GetAJoke("Chuck");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseDto = Assert.IsType<Response<JokeDto>>(okResult.Value);
            var jokeDto = responseDto.Data;
            Assert.Equal(expectedJokeDto.Id, jokeDto.Id);
            Assert.Equal(expectedJokeDto.JokeName, jokeDto.JokeName);
            Assert.Equal(expectedJokeDto.JokeDescription, jokeDto.JokeDescription);
        }

        [Fact]
        public async Task GetAJoke_ReturnsOkWithJokeDtoFromDad_WhenParamIsDad()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var serviceProvider = new ServiceCollection()
                .AddTransient(_ => mediatorMock.Object)
                .BuildServiceProvider();
            var controller = new JokeAndMathsController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { RequestServices = serviceProvider }
                }
            };
            var expectedJokeDto = new JokeDto { Id = "1", JokeName = "Joke from DadJokes", JokeDescription = "Dad joke" };
            var response = new Response<JokeDto>(expectedJokeDto);
            mediatorMock.Setup(x => x.Send(It.Is<GetJokeWithOptionalParam>(p => p.param == "Dad"), default)).ReturnsAsync(response);

            // Act
            var result = await controller.GetAJoke("Dad");

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
            var mediatorMock = new Mock<IMediator>();
            var serviceProvider = new ServiceCollection()
                .AddTransient(_ => mediatorMock.Object)
                .BuildServiceProvider();
            var controller = new JokeAndMathsController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { RequestServices = serviceProvider }
                }
            };
            var invalidParam = "InvalidParam";
            var expectedMessage = "That type of joke does not exists";
            mediatorMock.Setup(x => x.Send(It.Is<GetJokeWithOptionalParam>(p => p.param == invalidParam), default))
                        .ThrowsAsync(new KeyNotFoundException(expectedMessage));

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await controller.GetAJoke(invalidParam));
        }

    }
}
