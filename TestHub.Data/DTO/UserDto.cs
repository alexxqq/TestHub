namespace TestHub.DAL.DTO
{
    public class UserDto
    {
        public required string name { get; set; }
        public required string login { get; set; }
        public required string password_hash { get; set; }
        public required string role { get; set; }
        public required DateTime created_at { get; set; }
    }
}
