using System.ComponentModel.DataAnnotations;

namespace QuizoAPI.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        [StringLength(200)]
        public string Comments { get; set; } = string.Empty;

        public int QuizTypeId { get; set; }
        public QuizType? QuizName { get; set; }
    }
}
