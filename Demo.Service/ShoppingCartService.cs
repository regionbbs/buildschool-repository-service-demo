using BuildSchool.Mvc.Demo.Abstractions;
using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IShoppingCartRepository _shoppingCartRepository;
        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;

        public ShoppingCartService(
            IProductRepository productRepository, 
            ICustomerRepository customerRepository, 
            IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public void AddItem(IShoppingCart cart, IProduct product, int qty = 1)
        {
            _shoppingCartRepository.AddItem(cart, product, qty);
        }

        public void ClearCart(IShoppingCart cart)
        {
            _shoppingCartRepository.ClearCart(cart);
        }

        public IShoppingCart CreateNewCart(ICustomer customer)
        {
            return _shoppingCartRepository.CreateNewCart(customer);
        }

        public IShoppingCart GetActiveCart(ICustomer customer)
        {
            return _shoppingCartRepository.GetActiveCart(customer);
        }

        public IShoppingCart GetById(string Id)
        {
            return _shoppingCartRepository.GetById(Id);
        }

        public IEnumerable<IShoppingCartItem> GetItems(IShoppingCart cart)
        {
            return _shoppingCartRepository.GetItems(cart);
        }

        public void RemoveCart(IShoppingCart cart)
        {
            _shoppingCartRepository.RemoveCart(cart);
        }

        public void RemoveItem(IShoppingCart cart, IProduct product)
        {
            _shoppingCartRepository.RemoveItem(cart, product);
        }

        public void UpdateItem(IShoppingCart cart, IProduct product, int qty)
        {
            _shoppingCartRepository.UpdateItem(cart, product, qty);
        }
    }
}
