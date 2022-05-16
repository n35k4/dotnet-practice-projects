using System.Collections.Generic;
using Quizo.API.Models;

namespace Quizo.UnitTests.Fixtures;

public static class QuizFixture
{
    public static List<Quiz> GetTestQuizzes() => new()
        {
            new Quiz
            {
                Id = 1,
                Question = "This is sample Question 1.",
                Answer = "This is sample answer 1.",
                Difficulty = Difficulty.Medium
            },
            new Quiz
            {
                Id = 3,
                Question = "This is sample Question 3.",
                Answer = "This is sample answer 3.",
                Difficulty = Difficulty.Easy 
            },
            new Quiz
            {
            Id = 2,
            Question = "This is sample Question 4.",
            Answer = "This is sample answer 4.",
            Difficulty = Difficulty.Hard 
            },
            new Quiz
            {
            Id = 2,
            Question = "This is sample Question 5.",
            Answer = "This is sample answer 5.",
            Difficulty = Difficulty.Medium 
            }
        };
}