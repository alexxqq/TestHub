using TestHub.BLL.Interfaces;
using TestHub.DAL.Interfaces;
using TestHub.DAL.Models;
using TestHub.DAL.DTO;
using Serilog;

namespace TestHub.BLL.Services
{
    public class SupervisorService : ISupervisorService
    {
        private readonly ISupervisorRepository _supervisorRepository;

        public SupervisorService(ISupervisorRepository userRepository)
        {
            _supervisorRepository = userRepository;
            Log.Information("SupervisorService()");
        }

        public async Task<List<User>> GetAdminsAsync()
        {
            Log.Information("GetAdminsAsync() from service");
            return await _supervisorRepository.GetAdminsAsync();
        }

        public async Task AddAdminAsync(string name, string login, string password)
        {
            Log.Information("AddAdminAsync() from service");
            var user = new UserDto
            {
                name = name,
                login = login,
                password_hash = PasswordHasher.HashPassword(password), 
                role = "Admin",
                created_at = DateTime.UtcNow
            };

            await _supervisorRepository.AddAdminAsync(user);
        }

        public async Task DeleteAdminAsync(int userId)
        {
            Log.Information("DeleteAdminAsync() from service");
            await _supervisorRepository.DeleteAdminAsync(userId);
        }
    }

}
