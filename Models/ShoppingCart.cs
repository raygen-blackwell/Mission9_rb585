using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class ShoppingCart
    {
        [Key]
        [BindNever]
        public int CartId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter first name: ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name: ")]
        public string LasstName { get; set; }

        [Required(ErrorMessage = "Please enter address: ")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter city name: ")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter state: ")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter country: ")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter email: ")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
