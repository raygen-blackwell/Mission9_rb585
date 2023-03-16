using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book bi, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == bi.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bi,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book bi)
        {
            Items.RemoveAll(x => x.Book.BookId == bi.BookId);
        }

        public virtual void ClearBasket ()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }


    public class BasketLineItem
    {
        [Key]
        public int Line { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
