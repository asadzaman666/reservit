using System;
using System.Collections.Generic;
using System.Data.Entity;
using RRSEntity;

namespace RRSData
{
    public class EntityContextInitializer : DropCreateDatabaseIfModelChanges<RRSDBContext>
    {
        protected override void Seed(RRSDBContext context)
        {
            List<Grade> grades = new List<Grade>
            {
                new Grade {GradeName = "A", Id = 1},
                new Grade {GradeName = "B", Id = 2},
                new Grade {GradeName = "C", Id = 3}
                
            };

            foreach (var variable in grades)
            {
                context.Grades.Add(variable);
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Chris Moister", Email = "chris@email.com", Password = "chris", Phone = "9884574"},
            };

            foreach (var variable in customers)
            {
                context.Customers.Add(variable);
            }

            List<Admin> admins = new List<Admin>
            {
                new Admin {Id = 1, Email = "admin@email.com", Password = "admin"}
            };

            foreach (var variable in admins)
            {
                context.Admins.Add(variable);
            }

            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "The Violent Canteen", Email = "violentcanteen@email.com", Address = "300 feet, Purbachal, Dhaka", Phone = "9885656", GradeId = 3, Seats = 30, RestaurantAdminId = 1},
            };

            foreach (var variable in restaurants)
            {
                context.Restaurants.Add(variable);
            }

            List<RestaurantAdmin> restaurantAdmins = new List<RestaurantAdmin>
            {
                new RestaurantAdmin{Id = 1, Email = "violentcanteen@email.com", Password = "violent", RestaurantId = 1},
            };

            foreach (var variable in restaurantAdmins)
            {
                context.RestaurantAdmins.Add(variable);
            }

            string date = "Jan 1, 2009";
            List<Reservation> reservations = new List<Reservation>
            {
                new Reservation{Id = 1, RestaurantId = 1, CustomerId = 1, Date =date, NumberOfSeats = 5, SpecialNotes = "Arrival time around 4pm"}
            };

            foreach (var variable in reservations)
            {
                context.Reservations.Add(variable);
            }

            context.SaveChanges();
        }
    }
}
