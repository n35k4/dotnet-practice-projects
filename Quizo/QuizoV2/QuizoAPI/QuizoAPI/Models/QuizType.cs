using System.ComponentModel.DataAnnotations;

namespace QuizoAPI.Models
{
    public class QuizType
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string QuizName { get; set; } = string.Empty;
    }
}
