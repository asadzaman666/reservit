using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RRSInterface;
using RRSEntity;
using RRSRepository;

namespace RRSApp.Controllers
{
    [RoutePrefix("api/restaurants")]
    public class RestaurantController : ApiController
    {
        private IRestaurantRepository repo  = new RestaurantRepository();
        private IRestaurantAdminRepository restAdminRepo = new RestaurantAdminRepository();

        //public RestaurantController(IRestaurantRepository repo, IRestaurantAdminRepository restAdminRepo)
        //{
        //    this.repo = repo;
        //    this.restAdminRepo = this.restAdminRepo;
        //}

        [Route("")][HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

       [Route("New")]
       [HttpPost]
        public IHttpActionResult Insert(Restaurant restaurant)
       {
            restaurant.RestaurantAdminId = restAdminRepo.GetAll().LastOrDefault().RestaurantId;
            repo.Insert(restaurant);
            string url = Url.Link("GetRestaurant", new {id = restaurant.Id});
            return Created(url, restaurant);
        }

        [HttpGet] [Route( "{id}", Name = "GetRestaurant")]
        public IHttpActionResult Get(int id)
        {
            Restaurant rest = repo.Get(id);

            if (rest == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(rest);
            }
        }

        [HttpPut]
        [Route("{id}", Name = "UpdateRestaurant")]
        public IHttpActionResult Put([FromBody]Restaurant restaurant,  [FromUri]int id)
        {
            restaurant.Id = id;
            repo.Update(restaurant);
            return Ok(restaurant);
        }

        [HttpDelete]
        [Route("{id}", Name = "DeleteRestaurant")]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
