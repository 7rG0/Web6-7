using System.Security.Cryptography.X509Certificates;
using Web6_7.Interfaces;
using Web6_7.Models;

namespace Web6_7.Services
{
    public class AuthorData : IAuthorData
    {
        private List<Author> _authorList;

        public AuthorData()
        {
            _authorList = new List<Author>
        {
            new Author { Id = 1, AuthorName = "Evelyn Hartwell", BooksCount = 15 },
            new Author { Id = 2, AuthorName = "Daniel Crossfield", BooksCount = 7 },
            new Author { Id = 3, AuthorName = "Sophia Larkwood", BooksCount = 6 },
            new Author { Id = 4, AuthorName = "Kael Draven", BooksCount = 19 },
            new Author { Id = 5, AuthorName = "Aurelia Nightshade", BooksCount = 27 },
            new Author { Id = 6, AuthorName = "Thorne Ravenspark", BooksCount = 15 },
            new Author { Id = 7, AuthorName = "Lila Rosemont", BooksCount = 3 },
            new Author { Id = 8, AuthorName = "Sebastian Wainwright", BooksCount = 17 },
            new Author { Id = 9, AuthorName = "Victor Blackthorn", BooksCount = 21 },
            new Author { Id = 10, AuthorName = "Margot Sinclair", BooksCount = 25 },
        };
        }

        public Task<List<Author>> GetAllAsync()
        {
            return Task.FromResult(_authorList);
        }

        public Task<Author> AddAsync(Author model)
        {
            model.Id = _authorList.Max(x => x.Id) + 1;
            _authorList.Add(model);
            return Task.FromResult(model);
        }

        public Task<Author> UpdateAsync(int id, Author model)
        {
            var item = _authorList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.AuthorName = model.AuthorName;
                item.BooksCount = model.BooksCount;
                return Task.FromResult(item);
            }
            return Task.FromResult<Author>(null);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _authorList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _authorList.Remove(item);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
