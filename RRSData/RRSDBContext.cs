using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRSEntity;

namespace RRSData
{
    public class RRSDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RestaurantAdmin> RestaurantAdmins { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
