using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRSEntity;
using RRSInterface;

namespace RRSRepository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public List<Restaurant> GetRestaurantByGrade(int Id)
        {

            return null;
        }
    }
}
