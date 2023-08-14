using CustomerManagment.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomerManagment.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if(Customers.Count<Customer>()==0)
            { 
            GenerateData();
            SaveChanges();
            }
        }
        public void GenerateData()
        {
            var Customer1 = new Customer
            {

                Id = 1,
                First_Name = "James",
                Last_Name = "Smith",
                DoB = new DateTime(1999, 1, 24)
            };
            var Customer2 = new Customer
            {
                Id = 2,
                First_Name = "Maria",
                Last_Name = "Smith",
                DoB = new DateTime(2000, 3, 3)
            };
            var Customer3 = new Customer
            {
                Id = 3,
                First_Name = "David",
                Last_Name = "Johnson",
                DoB = new DateTime(1983, 5, 4)
            };
            Customers.Add(Customer1);
            Customers.Add(Customer2);
            Customers.Add(Customer3);
            
        }
    }
}
