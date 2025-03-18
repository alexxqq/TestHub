using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestHub.DAL.Models
{
    public enum QuestionType
    {
        Single,
        Multiple,
        OpenEnded,
        TrueFalse
    }

    [Table("questions")]
    public class Question
    {
        [Key]
        public int question_id { get; set; }
        public required int test_id { get; set; }
        public required string question_text { get; set; }
        public required QuestionType question_type { get; set; }
        public required List<Answer> answers { get; set; }
        [ForeignKey("test_id")]
        public required Test test { get; set; }
    }
}
