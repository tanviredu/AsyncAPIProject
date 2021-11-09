using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTO
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
