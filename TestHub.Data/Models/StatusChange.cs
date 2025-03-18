using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestHub.DAL.Models
{
    [Table("status_changes")]
    public class StatusChange
    {
        [Key]
        public int status_id { get; set; }
        public required int test_id { get; set; }
        public required int user_id { get; set; }
        public required string old_status { get; set; }
        public required string new_status { get; set; }
        public required DateTime changed_at { get; set; }
    }
}
