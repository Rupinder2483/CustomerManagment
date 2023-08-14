using Castle.Core.Resource;
using CustomerManagment.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.TestApi.MockData
{
    public class CustomersMockData
    {
        public static List<Customer> MockCustomers = new List<Customer>
        {
            new Customer
            {

                Id = 1,
                First_Name = "James",
                Last_Name = "Smith",
                DoB = new DateTime(1999, 1, 24)
            }, new Customer
            {
                Id = 2,
                First_Name = "Maria",
                Last_Name = "Smith",
                DoB = new DateTime(2000, 3, 3)
            }, new Customer
            {
                Id = 3,
                First_Name = "David",
                Last_Name = "Johnson",
                DoB = new DateTime(1983, 5, 4)
            }};
        }
    }

