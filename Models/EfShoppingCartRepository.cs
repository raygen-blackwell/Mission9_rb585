using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EfShoppingCartRepository : IShoppingCartRepository
    {
        private BookstoreContext context;

        public EfShoppingCartRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<ShoppingCart> ShoppingCarts => context.ShoppingCarts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCart(ShoppingCart sc)
        {
            context.AttachRange(sc.Lines.Select(x => x.Book));

            if (sc.CartId == 0)
            {
                context.ShoppingCarts.Add(sc);
            }

            context.SaveChanges();
        }
    }
}
