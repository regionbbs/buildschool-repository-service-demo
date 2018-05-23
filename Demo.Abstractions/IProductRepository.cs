using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IProductRepository
    {
        void Create(IProduct product);
        void Update(IProduct product);
        void Delete(IProduct product);
        IProduct Get(int id);
        IEnumerable<IProduct> GetAll();
    }
}
