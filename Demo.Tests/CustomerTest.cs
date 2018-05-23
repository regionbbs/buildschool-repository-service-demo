using System;
using System.Configuration;
using System.Linq;
using BuildSchool.Mvc.Demo.Models;
using BuildSchool.Mvc.Demo.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Tests
{
    [TestClass]
    public class CustomerTest
    {
        private DbOptions _dbOptions;

        [TestInitialize]
        public void Initialize()
        {
            _dbOptions = new DbOptions()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString
            };
        }

        [TestMethod]
        public void TestCustomerRepositoryLoad()
        {
            var repository = new CustomerRepository(_dbOptions);
            var customers = repository.GetAll();
            Assert.IsTrue(customers.Any());
        }
    }
}
