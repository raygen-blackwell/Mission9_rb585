using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class CartController : Controller
    {
        private IShoppingCartRepository repo { get; set; }
        private Basket basket { get; set; }

        public CartController (IShoppingCartRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new ShoppingCart());
        }

        [HttpPost]
        public IActionResult Checkout(ShoppingCart sc)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                sc.Lines = basket.Items.ToArray();
                repo.SaveCart(sc);
                basket.ClearBasket();

                return RedirectToPage("/CartCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
