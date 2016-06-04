using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using ASPNET_WebAPI_OData_Sample.Models.Models;
using Microsoft.OData.Edm;

namespace ASPNET_WebAPI_OData_Sample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());

            config.EnsureInitialized();
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
