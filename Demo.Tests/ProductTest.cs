using System;
using System.Configuration;
using System.Linq;
using BuildSchool.Mvc.Demo.Abstractions;
using BuildSchool.Mvc.Demo.Models;
using BuildSchool.Mvc.Demo.Repository;
using BuildSchool.Mvc.Demo.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace Demo.Tests
{
    [TestClass]
    public class ProductTest
    {
        private Container _container;

        [TestInitialize]
        public void Initialize()
        {
            _container = new Container();
            _container.Register<IProductRepository, ProductRepository>();
            _container.Register<IProductService, ProductService>();
            _container.RegisterInstance<IDbOptions>(new DbOptions()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString
            });
        }

        [TestMethod]
        public void TestProductRepository()
        {
            var repository = _container.GetInstance<IProductRepository>();
            var query = repository.GetAll();
            Assert.IsTrue(query.Any());
        }

        [TestMethod]
        public void TestProductService()
        {
            var service = _container.GetInstance<IProductService>();
            var query = service.GetAll();
            Assert.IsTrue(query.Any());
        }
    }
}
