using System;
using System.Runtime.ConstrainedExecution;
using Web6_7.Models;

namespace Web6_7.Interfaces

{
    public interface IBookData
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> AddAsync(Book model);
        Task<Book> UpdateAsync(int id, Book model);
        Task<bool> DeleteAsync(int id);
    }
}
