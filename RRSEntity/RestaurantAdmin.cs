using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRSEntity
{
    public class RestaurantAdmin : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RestaurantId { get; set; }

    }
}
