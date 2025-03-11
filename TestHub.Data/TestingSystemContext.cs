using Microsoft.EntityFrameworkCore;
using TestHub.DAL.Models;

namespace TestHub.DAL
{
    public class TestingSystemContext : DbContext, ITestingSystemContextDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<StatusChange> StatusChanges { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Env environment = new Env();
            optionsBuilder.UseNpgsql($"Server={environment.DbHost};Port={environment.DbPort};Database={environment.DbName};UserId={environment.DbUser};Password={environment.DbPass}");
        }
    }
}
