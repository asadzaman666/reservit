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
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        private IRepository<Admin> repo = new Repository<Admin>();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        [Route("{id}", Name = "GetAdmin")]
        public IHttpActionResult Get(int id)
        {
            Admin a = repo.Get(id);

            return Ok(a);
        }

        [HttpPost]
        [Route("New")]
        public IHttpActionResult Insert(Admin admin)
        {
            repo.Insert(admin);
            string url = Url.Link("GetAdmin", new { id = admin.Id });
            return Created(url, admin);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(Admin admin, [FromUri] int id)
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
