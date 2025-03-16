using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.DAL.DTO;

namespace TestHub.BLL.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<TestDto>> GetAllAsync();
        Task<TestDto?> GetByIdAsync(int id);
        Task AddAsync(TestDto testDto);
        Task<TestDto> UpdateAsync(int id, TestDto testDto);
        Task<bool> DeleteAsync(int id);
    }
}
