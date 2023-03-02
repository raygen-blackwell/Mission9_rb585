using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EfBookstoreRepository : IBooktoreRepository
    {
        private BookstoreContext context { get; set; }

        public EfBookstoreRepository(BookstoreContext temp)
        { 
            context = temp; 
        }

        public IQueryable<Book> Books => context.Books;
    }
}
