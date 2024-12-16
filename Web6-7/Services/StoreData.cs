using System.Security.Cryptography.X509Certificates;
using Web6_7.Interfaces;
using Web6_7.Models;

namespace Web6_7.Services
{
    public class StoreData : IStoreData
    {
        private List<Store> _storeList;

        public StoreData()
        {
            _storeList = new List<Store>
        {
            new Store { Id = 1, StoreName = "The Literary Haven", SaledBooks = 350 },
            new Store { Id = 2, StoreName = "Boundless Pages", SaledBooks = 170 },
            new Store { Id = 3, StoreName = "Chapter & Verse", SaledBooks = 500 },
            new Store { Id = 4, StoreName = "Whispering Tales", SaledBooks = 270 },
            new Store { Id = 5, StoreName = "The Bookmark Boutique", SaledBooks = 150 },
            new Store { Id = 6, StoreName = "Infinite Chapters", SaledBooks = 120 },
            new Store { Id = 7, StoreName = "The Story Nest", SaledBooks = 160 },
            new Store { Id = 8, StoreName = "Paperback Paradise", SaledBooks = 300 },
            new Store { Id = 9, StoreName = "The Reading Nook", SaledBooks = 210 },
            new Store { Id = 10, StoreName = "Tales & Treasures", SaledBooks = 95 },
        };
        }

        public Task<List<Store>> GetAllAsync()
        {
            return Task.FromResult(_storeList);
        }

        public Task<Store> AddAsync(Store model)
        {
            model.Id = _storeList.Max(x => x.Id) + 1;
            _storeList.Add(model);
            return Task.FromResult(model);
        }

        public Task<Store> UpdateAsync(int id, Store model)
        {
            var item = _storeList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.StoreName = model.StoreName;
                item.SaledBooks = model.SaledBooks;
                return Task.FromResult(item);
            }
            return Task.FromResult<Store>(null);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _storeList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _storeList.Remove(item);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
