using Microsoft.EntityFrameworkCore;
using QuizoAPI.Models;

namespace QuizoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Quiz> Quizzes { get; set; }
        
        public DbSet<QuizType> QuizTypes { get; set; }

        public DbSet<Status> Statuses { get; set; }

    }
}
