using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.DAL.Models;

namespace TestHub.DAL.DTO
{
    public class TestDto
    {
        public required string title { get; set; }
        public required string description { get; set; }
        public int user_id { get; set; } = 1;
        public required TestStatusType status { get; set; } = TestStatusType.Pending;
        public required AccessType visibility { get; set; }
        public int class_id { get; set; }
        public required string area { get; set; }
        public required int duration { get; set; }
        public DateTime available_from { get; set; }
        public DateTime available_to { get; set; }
        public int max_attempts { get; set; }
        public List<QuestionDto> questions { get; set; } = new();
    }
}
