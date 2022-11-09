using BusinessLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer) => CustomerDAO.Instance.AddCustomer(customer);

        public IEnumerable<Customer> GetCustomers() => CustomerDAO.Instance.GetCustomerList();

        public Customer GetCustomerById(int id) => CustomerDAO.Instance.GetCustomerByID(id);

        public void RemoveCustomer(Customer customer) => CustomerDAO.Instance.RemoveCustomer(customer);

        public void UpdateCustomer(Customer customer) => CustomerDAO.Instance.UpdateCustomer(customer);
    }
}
