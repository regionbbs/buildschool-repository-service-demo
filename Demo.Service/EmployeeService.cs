using BuildSchool.Mvc.Demo.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.Mvc.Demo.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Create(IEmployee employee)
        {
            _employeeRepository.Create(employee);
        }

        public void Delete(IEmployee employee)
        {
            _employeeRepository.Delete(employee);
        }

        public IEmployee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public IEnumerable<IEmployee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public void Update(IEmployee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}
