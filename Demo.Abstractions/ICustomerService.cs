using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface ICustomerService
    {
        void Create(ICustomer customer);
        void Update(ICustomer customer);
        void Delete(ICustomer customer);
        ICustomer Get(string id);
        IEnumerable<ICustomer> GetAll();
    }
}
