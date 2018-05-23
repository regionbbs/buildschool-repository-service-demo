using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IEmployeeRepository
    {
        void Create(IEmployee employee);
        void Update(IEmployee employee);
        void Delete(IEmployee employee);
        IEmployee Get(int id);
        IEnumerable<IEmployee> GetAll();
    }
}
