using CustomerManagment.BusinessLogicLayer.Interface;
using CustomerManagment.DataAccessLayer.Model;
using CustomerManagment.TestApi.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.TestApi.Mock
{
    public class CusotmersMock : Mock<ICustomersBLL>
    {
        public CusotmersMock GetCustomerList()
        {
            Setup(x => x.GetCustomerList()).ReturnsAsync(CustomersMockData.MockCustomers);
            return this;
        }

        public CusotmersMock GetCustomer()
        {
            Setup(x => x.GetCustomer(It.IsAny<int>())).ReturnsAsync(CustomersMockData.MockCustomers.First());
            return this;
        }
        public CusotmersMock GetCusotmers_Null()
        {
            Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));
            return this;
        }
       
        //      public Task<IEnumerable<Customer>> GetCustomerList();
        //// public Customer GetCustomer(int id);
        //public Task<Customer?> GetCustomer(int id);
        //public Customer CreateCustomer(Customer customer);
        //public HttpStatusCode DeleteCustomer(int id);
        //public HttpStatusCode UpdateCustomer(int id, Customer customer);
    }
}
