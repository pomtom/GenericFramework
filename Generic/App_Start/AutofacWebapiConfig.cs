using Autofac;
using Autofac.Integration.WebApi;
using Generic.Business.Service;
using Generic.Database;
using Generic.Database.Repository;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace Generic.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<DBCustomerEntities>()
            //       .As<DbContext>()
            //       .InstancePerRequest();

            //builder.RegisterType<DbFactory>()
            //       .As<IDbFactory>()
            //       .InstancePerRequest();

            //builder.RegisterGeneric(typeof(GenericRepository<>))
            //       .As(typeof(IGenericRepository<>))
            //       .InstancePerRequest();

            builder.RegisterType<GenericDbContext>()
                   .As<DbContext>();

            builder.RegisterType<EmployeeRepository>()
                   .As<IEmployeeRepository>();

            builder.RegisterType<EmployeeService>()
            .As<IEmployeeService>();


            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}