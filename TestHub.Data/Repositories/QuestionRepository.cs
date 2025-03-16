using Microsoft.EntityFrameworkCore;
using TestHub.DAL.Interfaces;
using TestHub.DAL.Models;

namespace TestHub.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TestingSystemContext _context;

        public QuestionRepository(TestingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.Include(q => q.answers).ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.answers)
                .FirstOrDefaultAsync(q => q.question_id == id);
        }

        public async Task<Question> AddAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
