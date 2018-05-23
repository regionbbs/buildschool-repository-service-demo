using System;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IShoppingCart
    {
        string ShoppingCartId { get; }
        string CustomerId { get; }
        DateTime DateCreated { get; }
    }
}
