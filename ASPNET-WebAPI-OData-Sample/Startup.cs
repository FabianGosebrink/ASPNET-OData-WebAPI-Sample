using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using ASPNET_WebAPI_OData_Sample.DataAccess;
using ASPNET_WebAPI_OData_Sample.Models.Models;
using Microsoft.OData.Edm;
using Microsoft.Owin;
using Ninject;
using Owin;
using WebApiContrib.IoC.Ninject;

[assembly: OwinStartup(typeof(ASPNET_WebAPI_OData_Sample.Startup))]

namespace ASPNET_WebAPI_OData_Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration
            {
                DependencyResolver = new NinjectResolver(CreateKernel())
            };

            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());

            config.EnsureInitialized();

            app.UseWebApi(config);
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IHouseRepository>().ToConstant(new HouseRepository());

            return kernel;
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder
            {
                Namespace = "ASPNET-WebAPI-OData-Sample"
            };

            builder.EntitySet<HouseEntity>("Houses");
            builder.EntitySet<PersonEntity>("Persons");

            return builder.GetEdmModel();
        }
    }
}
