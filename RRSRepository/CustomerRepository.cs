using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRSEntity;
using RRSInterface;

namespace RRSRepository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public List<Customer> CustomerId(string email, string password)
        {
            return Context.Customers.Where(c => c.Email == email && c.Password == password).ToList();
        }
    }
}
