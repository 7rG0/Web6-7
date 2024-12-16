using System.Security.Cryptography.X509Certificates;
using Web6_7.Interfaces;
using Web6_7.Models;

namespace Web6_7.Services
{
    public class BookData : IBookData
    {
        private List<Book> _bookList;

        public BookData()
        {
            _bookList = new List<Book>
        {
            new Book { Id = 1, BookName = "Shadows of the Forgotten Realm", Pages = 356 },
            new Book { Id = 2, BookName = "Crown of Ashes", Pages = 458 },
            new Book { Id = 3, BookName = "Echoes of the Vanished", Pages = 525 },
            new Book { Id = 4, BookName = "The Silent Witness", Pages = 272 },
            new Book { Id = 5, BookName = "Letters to the Moon", Pages = 190 },
            new Book { Id = 6, BookName = "When We Were Stardust", Pages = 211 },
            new Book { Id = 7, BookName = "The Quantum Paradox", Pages = 234 },
            new Book { Id = 8, BookName = "Unleashing the Inner Flame", Pages = 322 },
            new Book { Id = 9, BookName = "The Gatekeeper’s Oath", Pages = 247 },
            new Book { Id = 10, BookName = "The Melody of Us", Pages = 543 },
        };
        }

        public Task<List<Book>> GetAllAsync()
        {
            return Task.FromResult(_bookList);
        }

        public Task<Book> AddAsync(Book model)
        {
            model.Id = _bookList.Max(x => x.Id) + 1;
            _bookList.Add(model);
            return Task.FromResult(model);
        }

        public Task<Book> UpdateAsync(int id, Book model)
        {
            var item = _bookList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.BookName = model.BookName;
                item.Pages = model.Pages;
                return Task.FromResult(item);
            }
            return Task.FromResult<Book>(null);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _bookList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _bookList.Remove(item);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
