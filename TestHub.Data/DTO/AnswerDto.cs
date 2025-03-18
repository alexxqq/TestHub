using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.DAL.DTO
{
    public class AnswerDto
    {
        public required string answer_text { get; set; }
        public required bool is_correct { get; set; }
    }
}
