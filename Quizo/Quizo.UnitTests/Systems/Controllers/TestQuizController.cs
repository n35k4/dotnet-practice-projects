using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Quizo.API.Controllers;
using Quizo.API.Models;
using Quizo.API.Services;
using Quizo.UnitTests.Fixtures;
using Xunit;

namespace Quizo.UnitTests.Systems.Controllers;

public class UnitTest1
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
    // Arrange
    var mockUserService = new Mock<IQuizService>();
    mockUserService
        .Setup(service => service.GetAllQuizzes())
        .ReturnsAsync(QuizFixture.GetTestQuizzes());
    
    var sut = new QuizController(mockUserService.Object);
    
    // Act
    var result = (OkObjectResult)await sut.Get();
    
    // Assert
    result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesQuizServiceOnce()
    {
        // Arrange
        var mockQuizService = new Mock<IQuizService>();
        mockQuizService
            .Setup(service => service.GetAllQuizzes())
            .ReturnsAsync(new List<Quiz>());
        var sut = new QuizController(mockQuizService.Object);
        
        // Act
        var result = await sut.Get();
        
        // Assert
        mockQuizService.Verify(
            service => service.GetAllQuizzes(),
            Times.Once
            );
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfQuizzes()
    {
        // Arrange
        var mockQuizService = new Mock<IQuizService>();
        mockQuizService
            .Setup(service => service.GetAllQuizzes())
            .ReturnsAsync(QuizFixture.GetTestQuizzes());
        var sut = new QuizController(mockQuizService.Object);
        
        // Act
        var result = await sut.Get();
        
        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<Quiz>>();
    }
    
    [Fact]
    public async Task Get_OnUsersFound_Return404()
    {
        // Arrange
        var mockQuizService = new Mock<IQuizService>();
        mockQuizService
            .Setup(service => service.GetAllQuizzes())
            .ReturnsAsync(new List<Quiz>());
        var sut = new QuizController(mockQuizService.Object);
        
        // Act
        var result = await sut.Get();
        
        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}