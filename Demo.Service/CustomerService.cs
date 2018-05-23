using BuildSchool.Mvc.Demo.Abstractions;
using System;
using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(ICustomer customer)
        {
            _customerRepository.Create(customer);
        }

        public void Delete(ICustomer customer)
        {
            _customerRepository.Delete(customer);
        }

        public ICustomer Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICustomer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ICustomer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
