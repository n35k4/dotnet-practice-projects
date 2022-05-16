namespace Quizo.API.Models;

public class Quiz
{
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public Difficulty Difficulty { get; set; }
}