using System.Web.Http;
using RRSEntity;
using RRSInterface;
using Unity;
using Unity.WebApi;
using RRSRepository;
using Unity.RegistrationByConvention;

namespace RRSApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IRestaurantRepository, RestaurantRepository>();
            container.RegisterType<IRepository<Grade>, Repository<Grade>>();
            container.RegisterType<IRepository<Reservation>, Repository<Reservation>>();
            container.RegisterType<IRepository<RestaurantAdmin>, Repository<RestaurantAdmin>>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}