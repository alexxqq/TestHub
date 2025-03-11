using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestHub.DAL.Models
{
    public enum TestStatusType
    {
        Pending,
        Approved,
        Rejected,
        Repending
    }

    public enum AccessType
    {
        Public,
        Private
    }

    [Table("tests")]
    public class Test
    {
        [Key]
        public int test_id { get; set; }
        public required string title { get; set; }
        public required string description { get; set; }
        public int user_id { get; set; }
        public required TestStatusType status { get; set; }
        public required AccessType visibility { get; set; }
        public int class_id { get; set; }
        public required string area { get; set; }
        public required int duration { get; set; }
        public DateTime available_from { get; set; }
        public DateTime available_to { get; set; }
        public int max_attempts { get; set; }
    }
}
