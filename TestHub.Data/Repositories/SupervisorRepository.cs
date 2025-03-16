using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.DAL.Interfaces;
using TestHub.DAL.Models;
using TestHub.DAL.DTO;
using Serilog;

namespace TestHub.DAL.Repositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly TestingSystemContext _context;

        public SupervisorRepository(TestingSystemContext context)
        {
            Log.Information("SupervisorRepository() created");
            _context = context;
        }

        public async Task<List<User>> GetAdminsAsync()
        {
            Log.Information("GetAdminsAsync() from repo");
            return await _context.Users.Where(u => u.role == "Admin").ToListAsync();
        }

        public async Task AddAdminAsync(UserDto userDto)
        {
            Log.Information("AddAdminAsync() from repo");
            User newUser = new User
            {
                login = userDto.login,
                password_hash = userDto.password_hash,
                created_at = userDto.created_at,
                role = userDto.role,
                name = userDto.name,
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdminAsync(int userId)
        {
            Log.Information("DeleteAdminAsync() from repo");
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }

}
