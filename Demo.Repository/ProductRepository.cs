using BuildSchool.Mvc.Demo.Abstractions;
using BuildSchool.Mvc.Demo.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BuildSchool.Mvc.Demo.Repository
{
    public class ProductRepository : IProductRepository, IRepository<IProduct, int>
    {
        private IDbOptions _dbOptions;

        public ProductRepository(IDbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public void Create(IProduct product)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"INSERT INTO Products VALUES (@name, @sid, @catid, @qpu, @price, @qty, @qtyOrder, @qtyReorder, @discontinued)",
                new
                {
                    name = product.ProductName,
                    sid = product.SupplierID,
                    catid = product.CategoryID,
                    qpu = product.QuantityPerUnit,
                    price = product.UnitPrice,
                    qty = product.UnitsInStock,
                    qtyOrder = product.UnitsOnOrder,
                    qtyReorder = product.ReorderLevel,
                    discontinued = product.Discontinued
                });
        }

        public void Delete(IProduct product)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"DELETE FROM Products WHERE ProductID = @id",
                new
                {
                    id = product.ProductID
                });
        }

        public IProduct Get(int key)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            return connection.QuerySingle<Product>("SELECT * FROM Products");
        }

        public IEnumerable<IProduct> GetAll()
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            return connection.Query<Product>("SELECT * FROM Products");
        }

        public void Update(IProduct product)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"UPDATE Products SET ProductName = @name, SupplierID = @sid, CategoryID = @catid, QuantityPerUnit = @qpu, 
                                      UnitPrice = @price, UnitsInStock = @qty, UnitsOnOrder = @qtyOrder, ReorderLevel = @qtyReorder, 
                                      Discontinued = @discontinued
                  WHERE ProductID = @id",
                new
                {
                    id = product.ProductID,
                    name = product.ProductName,
                    sid = product.SupplierID,
                    catid = product.CategoryID,
                    qpu = product.QuantityPerUnit,
                    price = product.UnitPrice,
                    qty = product.UnitsInStock,
                    qtyOrder = product.UnitsOnOrder,
                    qtyReorder = product.ReorderLevel,
                    discontinued = product.Discontinued
                });
        }
    }
}
