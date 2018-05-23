using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IShoppingCartRepository
    {
        IShoppingCart CreateNewCart(ICustomer customer);
        void AddItem(IShoppingCart cart, IProduct product, int qty = 1);
        void UpdateItem(IShoppingCart cart, IProduct product, int qty);
        void RemoveItem(IShoppingCart cart, IProduct product);
        void ClearCart(IShoppingCart cart);
        void RemoveCart(IShoppingCart cart);
        IShoppingCart GetById(string Id);
        IShoppingCart GetActiveCart(ICustomer customer);
        IEnumerable<IShoppingCartItem> GetItems(IShoppingCart cart);
    }
}
