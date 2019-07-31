using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRSEntity
{
    public class Restaurant : Entity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Seats { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public int GradeId { get; set; }
        public int RestaurantAdminId { get; set; }

    }
}
