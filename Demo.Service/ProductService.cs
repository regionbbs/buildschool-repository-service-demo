using BuildSchool.Mvc.Demo.Abstractions;
using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(IProduct product)
        {
            _productRepository.Create(product);
        }

        public void Delete(IProduct product)
        {
            _productRepository.Delete(product);
        }

        public IProduct Get(int id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<IProduct> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(IProduct product)
        {
            _productRepository.Update(product);
        }
    }
}
