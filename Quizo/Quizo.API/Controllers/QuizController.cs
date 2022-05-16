using Microsoft.AspNetCore.Mvc;
using Quizo.API.Services;

namespace Quizo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;
    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    [HttpGet(Name = "GetQuizes")]
    public async Task<IActionResult> Get()
    {
        var quizzes = await _quizService.GetAllQuizzes();

        if (!quizzes.Any())
            return NotFound();
        
        return Ok(quizzes);
    }
}
