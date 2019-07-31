using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRSEntity;

namespace RRSInterface
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        List<Restaurant> GetRestaurantByGrade(int  id);
    }
}
