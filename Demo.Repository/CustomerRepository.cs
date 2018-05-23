using BuildSchool.Mvc.Demo.Abstractions;
using BuildSchool.Mvc.Demo.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BuildSchool.Mvc.Demo.Repository
{
    public class CustomerRepository : ICustomerRepository, IRepository<ICustomer, string>
    {
        private IDbOptions _dbOptions;

        public CustomerRepository(IDbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public void Create(ICustomer model)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"INSERT INTO Customers VALUES (@id, @cname, @ctname, @ctitle, @addr, @city, @region, @pc, @country, @phone, @fax)",
                new
                {
                    id = model.CustomerID,
                    cname = model.CompanyName,
                    ctname = model.ContactName,
                    ctitle = model.ContactTitle,
                    addr = model.Address,
                    city = model.City,
                    region = model.Region,
                    pc = model.PostalCode,
                    country = model.Country,
                    phone = model.Phone,
                    fax = model.Fax
                });
        }

        public void Delete(ICustomer model)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(@"DELETE FROM Customers WHERE CustomerID = @id",
                new
                {
                    id = model.CustomerID
                });
        }

        public ICustomer Get(string key)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            return connection.QuerySingle<Customer>("SELECT * FROM Customers WHERE CustomerID = @id", new { id = key });
        }

        public IEnumerable<ICustomer> GetAll()
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            return connection.Query<Customer>("SELECT * FROM Customers");
        }

        public void Update(ICustomer model)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"UPDATE Customers SET CompanyName = @cname, ContactName = @ctname, ContactTitle = @ctitle, Address = @addr, 
                                       City = @city, Region = @region, PostalCode = @pc, Country = @country, Phone = @phone, Fax = @fax
                  WHERE CustomerID = @id",
                new
                {
                    id = model.CustomerID,
                    cname = model.CompanyName,
                    ctname = model.ContactName,
                    ctitle = model.ContactTitle,
                    addr = model.Address,
                    city = model.City,
                    region = model.Region,
                    pc = model.PostalCode,
                    country = model.Country,
                    phone = model.Phone,
                    fax = model.Fax
                });
        }
    }
}
