using Microsoft.EntityFrameworkCore;
using Serilog;
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

        //Old db configuration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    Env environment = new Env();
        //    optionsBuilder.UseNpgsql($"Server={environment.DbHost};Port={environment.DbPort};Database={environment.DbName};UserId={environment.DbUser};Password={environment.DbPass}");
        //}

        public TestingSystemContext(DbContextOptions<TestingSystemContext> options)
        : base(options) {
            Log.Information("TestingSystemContext() created");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Log.Information("OnModelCreating() started");
            modelBuilder.Entity<Question>()
                .HasOne(q => q.test)
                .WithMany(t => t.questions)
                .HasForeignKey(q => q.test_id)
                .OnDelete(DeleteBehavior.Cascade); // Якщо видаляється тест, видаляються і питання

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.question)
                .WithMany(q => q.answers)
                .HasForeignKey(a => a.question_id)
                .OnDelete(DeleteBehavior.Cascade); // Якщо видаляється питання, видаляються і відповіді
        }
    }
}
