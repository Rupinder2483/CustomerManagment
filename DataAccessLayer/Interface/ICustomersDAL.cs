using CustomerManagment.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.DataAccessLayer.Interface
{
    public interface ICustomersDAL
    {
        public Task<IEnumerable<Customer>> GetCustomerList();
        public Task<Customer?> GetCustomer(int id);
        public Customer CreateCustomer(Customer customer);
        public HttpStatusCode DeleteCustomer(int id);
        public HttpStatusCode UpdateCustomer(int id, Customer customer);
    }
}
