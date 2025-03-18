using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TestHub.DAL.Models
{
    [Table("members")]
    public class Member
    {
        [Key]
        public int member_id { get; set; }
        public required int class_id { get; set; }
        public required int user_id { get; set; }
    }
}