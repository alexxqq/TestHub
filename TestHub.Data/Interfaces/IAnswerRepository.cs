using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.DAL.Models;

namespace TestHub.DAL.Interfaces
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAllAsync();
        Task<Answer?> GetByIdAsync(int id);
        Task<Answer> AddAsync(Answer answer);
        Task<Answer> UpdateAsync(Answer answer);
        Task<bool> DeleteAsync(int id);
    }
}
