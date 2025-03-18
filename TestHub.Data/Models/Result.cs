using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TestHub.DAL.Models
{
    [Table("results")]
    public class Result
    {
        [Key]
        public int result_id { get; set; }
        public required int test_id { get; set; }
        public required int user_id { get; set; }
        public int attempt_number { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? completed_at { get; set; }
        public decimal? score { get; set; }
        public string? user_report { get; set; }
    }
}
