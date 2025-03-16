using TestHub.DAL.Models;
using TestHub.DAL.DTO;
namespace TestHub.DAL.Interfaces
{
    public interface ISupervisorRepository
    {
        Task<List<User>> GetAdminsAsync();
        Task AddAdminAsync(UserDto userDto);
        Task DeleteAdminAsync(int userId);
    }
}
