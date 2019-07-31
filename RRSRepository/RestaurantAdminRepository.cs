using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRSEntity;
using RRSInterface;

namespace RRSRepository
{
    public class RestaurantAdminRepository : Repository<RestaurantAdmin>, IRestaurantAdminRepository
    {
        public List<RestaurantAdmin> GetLastColumnId()
        {
            return this.Context.Set<RestaurantAdmin>().ToList();
        }
    }
}
