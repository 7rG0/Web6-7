using System;
using System.Runtime.ConstrainedExecution;
using Web6_7.Models;

namespace Web6_7.Interfaces

{
    public interface IStoreData
    {
        Task<List<Store>> GetAllAsync();
        Task<Store> AddAsync(Store model);
        Task<Store> UpdateAsync(int id, Store model);
        Task<bool> DeleteAsync(int id);
    }
}
