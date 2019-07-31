using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RRSApp.Attributes;
using RRSEntity;
using RRSInterface;
using RRSRepository;

namespace RRSApp.Controllers
{
    [RoutePrefix("api/reservations")]
    public class ReservationController : ApiController
    {
        private IRepository<Reservation> repo = new Repository<Reservation>();
        private ICustomerRepository CustomerRepo = new CustomerRepository();
        private IRestaurantAdminRepository restAdminRepo = new RestaurantAdminRepository();

        [Route("{id}", Name = "GetReservation")][BasicAuthentication]
        public IHttpActionResult Get(int id)
        {
            Reservation r = repo.Get(id);

            if (r == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(r);
            }
        }

        [Route("reservationbyrestaurant/{id}")]
        [HttpGet]
        public IHttpActionResult ByRestaurant([FromUri]int id)
        {
            var reservation =  repo.GetAll().Where(
                x => x.RestaurantId == id
            ).ToList();

            return Ok(reservation);
        }

        [Route("reservationbycustomer/{id}")]
        [HttpGet]
        [BasicAuthentication]
        public IHttpActionResult ByCustomer([FromUri]int id)
        {
            var reservation = repo.GetAll().Where(
                x => x.CustomerId == id
            ).ToList();

            return Ok(reservation);
        }

        [Route("New")][BasicAuthentication]
        [HttpPost]
        public IHttpActionResult Insert(Reservation reservation)
        {
                repo.Insert(reservation);
                string url = Url.Link("GetReservation", new { id = reservation.Id });
                return Created(url, reservation);
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }
    }
}
