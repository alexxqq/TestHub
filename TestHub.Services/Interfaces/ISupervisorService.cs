using TestHub.DAL.Models;

namespace TestHub.BLL.Interfaces
{
    public interface ISupervisorService
    {
        Task<List<User>> GetAdminsAsync();
        Task AddAdminAsync(string name, string login, string password);
        Task DeleteAdminAsync(int userId);
    }

}
