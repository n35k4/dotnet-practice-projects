using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Quizo.API.Models;
using Quizo.API.Models.Config;
using Quizo.API.Services;
using Quizo.UnitTests.Fixtures;
using Quizo.UnitTests.Helpers;
using Xunit;

namespace Quizo.UnitTests.Systems.Services;

public class TestQuizService
{
    [Fact]
    public async Task GetAllQuizzes_WhenCalled_InvokesHttpGetRequest()
    {
        // Arrange
        var expectedResponse = QuizFixture.GetTestQuizzes();
        var handlerMock = MockHttpMessageHandler<Quiz>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);

        var endpoint = "https://example.com";
        
        var config = Options.Create(new QuizApiOptions
        { 
            Endpoint = endpoint
        });
        
        var sut = new QuizService(httpClient, config);
        
        // Act
        await sut.GetAllQuizzes();
        
        // Asserts
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetAllUsers_WhenHits404_ReturnEmptyListOfUsers()
    {
        // Arrange
        var expectedResponse = QuizFixture.GetTestQuizzes();
        var handlerMock = MockHttpMessageHandler<Quiz>.SetupReturn404();
        var httpClient = new HttpClient(handlerMock.Object);
        var endpoint = "https://example.com";
        
        var config = Options.Create(new QuizApiOptions
        { 
            Endpoint = endpoint
        });
        
        var sut = new QuizService(httpClient, config);
        
        // Act
        var result = await sut.GetAllQuizzes();
        
        // Asserts
        result.Count.Should().Be(0);
    }
    
    [Fact]
    public async Task GetAllUsers_WhenCalled_ReturnListOfUsersOfExpectedSize()
    {
        // Arrange
        var expectedResponse = QuizFixture.GetTestQuizzes();
        var handlerMock = MockHttpMessageHandler<Quiz>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var endpoint = "https://example.com";
        
        var config = Options.Create(new QuizApiOptions
        { 
            Endpoint = endpoint
        });
        
        var sut = new QuizService(httpClient, config);
        
        // Act
        var result = await sut.GetAllQuizzes();
        
        // Asserts
        result.Count.Should().Be(expectedResponse.Count);
    }
    
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
    {
        // Arrange
        var expectedResponse = QuizFixture.GetTestQuizzes();
        const string endpoint = "https://example.com/quiz";
        var handlerMock = MockHttpMessageHandler<Quiz>
            .SetupBasicGetResourceList(expectedResponse, endpoint);
        var httpClient = new HttpClient(handlerMock.Object);

        var config = Options.Create(new QuizApiOptions
        { 
            Endpoint = endpoint
        });
        
        var sut = new QuizService(httpClient, config);
        
        // Act
        var result = await sut.GetAllQuizzes(); 
        var uri = new Uri(endpoint);
        // Asserts
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get 
                                                     && req.RequestUri.ToString() == endpoint),
                ItExpr.IsAny<CancellationToken>());
    }
    
}