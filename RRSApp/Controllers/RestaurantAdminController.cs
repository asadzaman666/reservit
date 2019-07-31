using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RRSEntity;
using RRSInterface;
using RRSRepository;

namespace RRSApp.Controllers
{
    [RoutePrefix("api/restaurantadmins")]

    public class RestaurantAdminController : ApiController
    {
        private RestaurantAdminRepository repo = new RestaurantAdminRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        [Route("{id}", Name = "GetRestaurantAdmin")]
        public IHttpActionResult Get(int id)
        {
            RestaurantAdmin r = repo.Get(id);

            return Ok(r);
        }

        [Route("ByAuth")]
        [HttpPost]
        public IHttpActionResult Find([FromBody]RestaurantAdmin customerN)
        {
            var customer = repo.GetAll().SingleOrDefault(c => c.Email == customerN.Email && c.Password == customerN.Password);
            return Ok(customer);
        }

        [HttpPost]
        [Route("New")]
        public IHttpActionResult Insert(RestaurantAdmin admin)
        {
            admin.RestaurantId = repo.GetAll().LastOrDefault().RestaurantId + 1;
            repo.Insert(admin);
            string url = Url.Link("GetRestaurantAdmin", new { id = admin.Id });
            return Created(url, admin);
        }

        [Route("{id}")]
        public IHttpActionResult Put(RestaurantAdmin admin, [FromUri] int id)
        {
            admin.Id = id;
            repo.Update(admin);
            return Ok(admin);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
