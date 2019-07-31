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
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        private ICustomerRepository repo = new CustomerRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            var id = repo.GetAll();
            return Ok(id);
        }

        [HttpPost]
        [Route("ByAuth")]
        public IHttpActionResult Find([FromBody]Customer customerN)
        {
            var customer = repo.GetAll().SingleOrDefault(c => c.Email == customerN.Email && c.Password == customerN.Password);
            return Ok(customer);
        }

        [Route("{id}", Name = "GetCustomer")]
        public IHttpActionResult Get(int id)
        {
            Customer c = repo.Get(id);

            return Ok(c);
        }

        [HttpPost]
        [Route("New")] 
        public IHttpActionResult Insert(Customer customer)
        {
            repo.Insert(customer);
            string url = Url.Link("GetCustomer", new {id = customer.Id});
            return Created(url, customer);
        }

        [HttpPut]
        [Route("{id}")][BasicAuthentication]
        public IHttpActionResult Put([FromBody] Customer customer, [FromUri] int id)
        {
            customer.Id = id;
            repo.Update(customer);
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id}")] [BasicAuthentication]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(repo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

         
    }
}
