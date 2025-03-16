using Microsoft.EntityFrameworkCore;
using TestHub.BLL.Interfaces;
using TestHub.DAL.DTO;
using TestHub.DAL.Interfaces;
using TestHub.DAL.Models;

namespace TestHub.BLL.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<IEnumerable<TestDto>> GetAllAsync()
        {
            var tests = await _testRepository.GetAllAsync();
            return tests.Select(t => new TestDto
            {
                title = t.title,
                description = t.description,
                user_id = t.user_id,
                status = t.status,
                visibility = t.visibility,
                class_id = t.class_id,
                area = t.area,
                duration = t.duration,
                available_from = t.available_from,
                available_to = t.available_to,
                max_attempts = t.max_attempts,
                questions = t.questions.Select(q => new QuestionDto
                {
                    question_text = q.question_text,
                    question_type = q.question_type,
                    answers = q.answers.Select(a => new AnswerDto
                    {
                        answer_text = a.answer_text,
                        is_correct = a.is_correct
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        public async Task<TestDto?> GetByIdAsync(int id)
        {
            var test = await _testRepository.GetByIdAsync(id);
            if (test == null) return null;

            return new TestDto
            {
                title = test.title,
                description = test.description,
                user_id = test.user_id,
                status = test.status,
                visibility = test.visibility,
                class_id = test.class_id,
                area = test.area,
                duration = test.duration,
                available_from = test.available_from,
                available_to = test.available_to,
                max_attempts = test.max_attempts,
                questions = test.questions.Select(q => new QuestionDto
                {
                    question_text = q.question_text,
                    question_type = q.question_type,
                    answers = q.answers.Select(a => new AnswerDto
                    {
                        answer_text = a.answer_text,
                        is_correct = a.is_correct
                    }).ToList()
                }).ToList()
            };
        }

        public async Task AddAsync(TestDto testDto)
        {
            await _testRepository.AddAsync(testDto);
        }
        public async Task<TestDto> UpdateAsync(int id, TestDto testDto)
        {
            var existingTest = await _testRepository.GetByIdAsync(id);
            if (existingTest == null) throw new KeyNotFoundException("Test not found");

            existingTest.title = testDto.title;
            existingTest.description = testDto.description;
            existingTest.status = testDto.status;
            existingTest.visibility = testDto.visibility;
            existingTest.class_id = testDto.class_id;
            existingTest.area = testDto.area;
            existingTest.duration = testDto.duration;
            existingTest.available_from = testDto.available_from;
            existingTest.available_to = testDto.available_to;
            existingTest.max_attempts = testDto.max_attempts;

            await _testRepository.UpdateAsync(existingTest);
            return testDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _testRepository.DeleteAsync(id);
        }
    }
}
