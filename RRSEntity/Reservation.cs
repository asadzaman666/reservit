using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRSEntity
{
    public class Reservation : Entity
    {
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public int NumberOfSeats { get; set; }
        public string SpecialNotes { get; set; }
        public int RestaurantId { get; set; }
 
    }
}
