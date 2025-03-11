using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TestHub.DAL.Models
{
    [Table("messages")]
    public class Message
    {
        [Key]
        public int message_id { get; set; }
        public required int sender_id { get; set; }
        public int recipient_id { get; set; }
        public int class_id { get; set; }
        public required string content { get; set; }
        public required DateTime sent_at { get; set; }
    }
}