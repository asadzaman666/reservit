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
    [RoutePrefix("api/grades")]

    public class GradeController : ApiController
    {
        private IRepository<Grade> repo = new Repository<Grade>();


        [Route("")] [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        [HttpPost] [Route("Insert")]
        public IHttpActionResult Insert(Grade grade)
        {
            repo.Insert(grade);
            //string url = Url.Link("GetRestaurant", new { id = grade.Id });
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
