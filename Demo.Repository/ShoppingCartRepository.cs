using BuildSchool.Mvc.Demo.Abstractions;
using BuildSchool.Mvc.Demo.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BuildSchool.Mvc.Demo.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private IDbOptions _dbOptions;

        public ShoppingCartRepository(IDbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public void AddItem(IShoppingCart cart, IProduct product, int qty = 1)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                var query = connection.Query("SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @cartId AND ProductId = @productId",
                    new
                    {
                        cartId = cart.ShoppingCartId,
                        productId = product.ProductID
                    });

                if (query.Any())
                {
                    connection.Execute("UPDATE ShoppingCartItems SET Qty = Qty + @qty WHERE ShoppingCartId = @cartId AND ProductId = @productId", new
                    {
                        cartId = cart.ShoppingCartId,
                        productId = product.ProductID,
                        qty
                    });
                }
                else
                {
                    connection.Execute("INSERT INTO ShoppingCartItems (ShoppingCartId, ProductId, Qty) VALUES (@cartId, @productId, @qty)", new
                    {
                        cartId = cart.ShoppingCartId,
                        productId = product.ProductID,
                        qty
                    });
                }
            }
        }

        public void ClearCart(IShoppingCart cart)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                connection.Execute("DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @cartId", new
                {
                    cartId = cart.ShoppingCartId
                });
            }
        }

        public IShoppingCart CreateNewCart(ICustomer customer)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            var newCartId = Guid.NewGuid();
            connection.Execute("INSERT INTO ShoppingCarts VALUES (@cartID, @customerID, GETDATE())", new
            {
                cartID = newCartId,
                customerID = customer.CustomerID
            });

            return new ShoppingCart()
            {
                ShoppingCartId = newCartId.ToString(),
                CustomerId = customer.CustomerID,
                DateCreated = DateTime.Now
            };
        }

        public IShoppingCart GetActiveCart(ICustomer customer)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                return connection.QueryFirstOrDefault<ShoppingCart>("SELECT * FROM ShoppingCarts WHERE CustomerID = @customerId ORDER BY DateCreated DESC",
                    new
                    {
                        customerId = customer.CustomerID
                    });
            }
        }

        public IShoppingCart GetById(string Id)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                return connection.QueryFirstOrDefault<ShoppingCart>("SELECT * FROM ShoppingCarts WHERE ShoppingCartId = @id",
                    new
                    {
                        id = Id
                    });
            }
        }

        public IEnumerable<IShoppingCartItem> GetItems(IShoppingCart cart)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                return connection.Query<ShoppingCartItem>("SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @id",
                    new
                    {
                        id = cart.ShoppingCartId
                    });
            }
        }

        public void RemoveCart(IShoppingCart cart)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                connection.Execute("DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @id", new { id = cart.ShoppingCartId });
                connection.Execute("DELETE FROM ShoppingCarts WHERE ShoppingCartId = @id", new { id = cart.ShoppingCartId });
            }
        }

        public void RemoveItem(IShoppingCart cart, IProduct product)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                connection.Execute("DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @cartId AND ProductId = @productId", new
                {
                    cartId = cart.ShoppingCartId,
                    productId = product.ProductID
                });
            }
        }

        public void UpdateItem(IShoppingCart cart, IProduct product, int qty)
        {
            using (var connection = new SqlConnection(_dbOptions.ConnectionString))
            {
                connection.Execute("UPDATE ShoppingCartItems SET Qty = @qty WHERE ShoppingCartId = @cartId AND ProductId = @productId", new
                {
                    cartId = cart.ShoppingCartId,
                    productId = product.ProductID,
                    qty
                });
            }
        }
    }
}
