using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestHub.DAL.Models
{
    [Table("answers")]
    public class Answer
    {
        [Key]
        public int answer_id { get; set; }
        public required int question_id { get; set; }
        public required string answer_text { get; set; }
        public required bool is_correct { get; set; }
    }
}
