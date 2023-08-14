using CustomerManagment.BusinessLogicLayer.Interface;
using CustomerManagment.DataAccessLayer.Interface;
using CustomerManagment.DataAccessLayer.Model;
using System.Net;

namespace CustomerManagment.BusinessLogicLayer
{
    public class CustomersBLL:ICustomersBLL
    {
        ICustomersDAL _dll;
        public CustomersBLL(ICustomersDAL dll)
        {
            _dll = dll; 
        }
        public async Task<IEnumerable<Customer>> GetCustomerList()
        {
            return await _dll.GetCustomerList();
        }

        public async Task<Customer> GetCustomer(int id)
        {
           return await _dll.GetCustomer(id);

        }

        public Customer CreateCustomer(Customer customer)
        {
            return _dll.CreateCustomer(customer);
        }

        public HttpStatusCode DeleteCustomer(int id)
        {
          return  _dll.DeleteCustomer(id);
        }
        public HttpStatusCode UpdateCustomer(int id, Customer customer)
        {
            return _dll.UpdateCustomer(id, customer);
        }
    }
}