using CustomerManagment.DataAccessLayer.Interface;
using CustomerManagment.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CustomerManagment.DataAccessLayer
{
    public class CustomersDAL:ICustomersDAL
    {
        private readonly ApplicationDbContext _db;
        public CustomersDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Customer>> GetCustomerList()
        {
            return _db.Customers.ToList();

        }

        public async Task<Customer> GetCustomer(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);

        }

        public Customer CreateCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return customer;
        }
        public HttpStatusCode DeleteCustomer(int id)
        {
           var customer = _db.Customers.FirstOrDefault(c=>c.Id == id);
            if (customer == null)
            {
            return HttpStatusCode.NotFound;
            }
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return HttpStatusCode.NoContent;
        }
        public HttpStatusCode UpdateCustomer(int id,Customer customer)
        {
            var customerDB= _db.Customers.AsNoTracking().FirstOrDefault(c=>c.Id==id);
            if (customerDB == null)
            {
                return HttpStatusCode.NotFound;
            }
            _db.Entry(customer).State = EntityState.Modified;
            _db.SaveChanges();
            return HttpStatusCode.NoContent;
        }
    }
}