using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface ICustomerRepository
    {
        void Create(ICustomer customer);
        void Update(ICustomer customer);
        void Delete(ICustomer customer);
        ICustomer Get(string id);
        IEnumerable<ICustomer> GetAll();
    }
}
