using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TestHub.DAL.Models
{
    [Table("classes")]
    public class Class
    {
        [Key]
        public int class_id { get; set; }
        public required string name { get; set; }
        public required int user_id { get; set; }
    }
}