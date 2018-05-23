using BuildSchool.Mvc.Demo.Abstractions;
using System;

namespace BuildSchool.Mvc.Demo.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public string CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
