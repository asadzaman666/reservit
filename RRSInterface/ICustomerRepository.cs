using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRSEntity;

namespace RRSInterface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> CustomerId(string email, string password);

    }
}
