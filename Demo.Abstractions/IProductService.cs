using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IProductService
    {
        void Create(IProduct product);
        void Update(IProduct product);
        void Delete(IProduct product);
        IProduct Get(int id);
        IEnumerable<IProduct> GetAll();
    }
}
