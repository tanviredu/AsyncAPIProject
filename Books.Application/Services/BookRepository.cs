using Books.Domain;
using Books.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }

     

        public void AddBook(Book bookToAdd)
        {
            if (bookToAdd == null) {

                throw new ArgumentNullException(nameof(bookToAdd));

            }
            _context.Add(bookToAdd);
        }

        public async Task<Book> GetBookByIdAsync(int Id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == Id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(b=>b.Author).ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
