using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using RRSInterface;
using RRSRepository;

namespace RRSApp.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private ICustomerRepository repo = new CustomerRepository();
        private IRestaurantAdminRepository restAdmin = new RestaurantAdminRepository();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;

                string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(token));


                string[] arr = decodedString.Split(new char[] { ':' });
                string username = arr[0];
                string password = arr[1];

                var customer = repo.GetAll().SingleOrDefault(c => c.Email == username && c.Password == password);

                if (customer.Email == username && customer.Password == password)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}