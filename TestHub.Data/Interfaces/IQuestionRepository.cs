﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.DAL.Models;

namespace TestHub.DAL.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id);
        Task<Question> AddAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        Task<bool> DeleteAsync(int id);
    }
}
