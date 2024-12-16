using System;
using System.Runtime.ConstrainedExecution;
using Web6_7.Models;

namespace Web6_7.Interfaces

{
    public interface IAuthorData
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> AddAsync(Author model);
        Task<Author> UpdateAsync(int id, Author model);
        Task<bool> DeleteAsync(int id);
    }
}
