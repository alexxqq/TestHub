using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.DAL.DTO;
using TestHub.DAL.Models;

namespace TestHub.DAL.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test?> GetByIdAsync(int id);
        Task<Test> AddAsync(Test test);
        Task<Test> AddAsync(TestDto testDto);
        Task<Test> UpdateAsync(Test test);
        Task<bool> DeleteAsync(int id);
    }
}
