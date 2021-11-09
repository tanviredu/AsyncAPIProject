using Books.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int Id);
        void AddBook(Book bookToAdd);
        Task<bool> SaveChangeAsync();

    }
}
