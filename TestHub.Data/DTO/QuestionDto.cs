using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.DAL.Models;

namespace TestHub.DAL.DTO
{
    public class QuestionDto
    {
        public required string question_text { get; set; }
        public required QuestionType question_type { get; set; }
        public List<AnswerDto> answers { get; set; } = new();
    }
}
