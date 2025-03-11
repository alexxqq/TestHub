using Microsoft.EntityFrameworkCore;
using TestHub.DAL.Models;

namespace TestHub.DAL
{
    public interface ITestingSystemContextDbContext:IDisposable
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

        int SaveChanges();
    }
}
