using Microsoft.EntityFrameworkCore;
using TestHub.DAL.DTO;
using TestHub.DAL.Interfaces;
using TestHub.DAL.Models;

namespace TestHub.DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly TestingSystemContext _context;

        public TestRepository(TestingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return await _context.Tests.Include(t => t.questions).ThenInclude(q => q.answers).ToListAsync();
        }

        public async Task<Test?> GetByIdAsync(int id)
        {
            return await _context.Tests
                .Include(t => t.questions)
                .ThenInclude(q => q.answers)
                .FirstOrDefaultAsync(t => t.test_id == id);
        }

        public async Task<Test> AddAsync(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<Test> AddAsync(TestDto testDto)
        {
            var test = new Test
            {
                title = testDto.title,
                description = testDto.description,
                status = TestStatusType.Pending,
                visibility = testDto.visibility,
                class_id = 0,
                area = testDto.area,
                duration = testDto.duration,
                available_from = testDto.available_from,
                available_to = testDto.available_to,
                max_attempts = testDto.max_attempts, 
                questions = new()
            };

            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            foreach (var questionDto in testDto.questions)
            {
                var question = new Question
                {
                    test_id = test.test_id,
                    question_type = questionDto.question_type,
                    question_text = questionDto.question_text,
                    test = test,
                    answers = new()
                };

                _context.Questions.Add(question);
                await _context.SaveChangesAsync(); 
                foreach (var answerDto in questionDto.answers)
                {
                    var answer = new Answer
                    {
                        question_id = question.question_id,
                        answer_text = answerDto.answer_text,
                        is_correct = answerDto.is_correct,
                        question = question
                    };

                    _context.Answers.Add(answer);
                }

                await _context.SaveChangesAsync(); 
            }
            return test;
        }

        public async Task<Test> UpdateAsync(Test test)
        {
            _context.Tests.Update(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null) return false;

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
