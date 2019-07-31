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

            List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Chris Myass", Email = "cmas@email.com", Password = "cmas", Phone = "01714857489"},
            };

            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "The Violent Canteen", Email = "violentcanteen@email.com", Address = "Narayanganj", Phone = "9885656", Grade = new Grade{GradeName = "C", Id = 3}, MaxSeat = 30}
            };

            foreach (var variable in grades)
            {
                context.Grades.Add(variable);
            }

            foreach (var variable in customers)
            {
                context.Customers.Add(variable);
            }

            foreach (var variable in restaurants)
            {
                context.Restaurants.Add(variable);
            }

            context.SaveChanges();
        }
    }
}
