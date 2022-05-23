using Microsoft.Extensions.Options;
using Quizo.API.Models;
using Quizo.API.Models.Config;

namespace Quizo.API.Services;

public interface IQuizService
{
    public Task<List<Quiz>> GetAllQuizzes();
}

// public class QuizServiceMock : IQuizService
// {
//     public async Task<List<Quiz>> GetAllQuizzes()
//     {
//         // return new Task<List<Quiz>>((() => new List<Quiz>()));
//         await Task.Delay(1000).ConfigureAwait(false);
//         Task.Run(() => { Console.Write("STH"); });
//         return new List<Quiz>();
//     }
// }

public class QuizService : IQuizService
{
    private readonly HttpClient _httpClient;
    private readonly QuizApiOptions _apiConfig;

    public QuizService(HttpClient httpClient, IOptions<QuizApiOptions> apiConfig)
    {
        _httpClient = httpClient;
        _apiConfig = apiConfig.Value;
    }
    public async Task<List<Quiz>> GetAllQuizzes()
    {
        var quizResponse = await _httpClient.GetAsync(_apiConfig.Endpoint);
        
        if (quizResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            return new List<Quiz>();

        var responseContent = quizResponse.Content;
        var allQuizzes = await responseContent.ReadFromJsonAsync<List<Quiz>>();
        return allQuizzes.ToList();
    }
}