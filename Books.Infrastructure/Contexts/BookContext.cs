using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Contexts
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext>opt):base(opt)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        
    }
}
