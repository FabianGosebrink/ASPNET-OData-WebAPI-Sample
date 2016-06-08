using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.DatabaseContext
{
    public class ODataSampleContext : DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<HouseEntity> Houses { get; set; }

        public ODataSampleContext() : base("ODataSample")
        {
            Database.SetInitializer(new ODataSampleContextInitializer());
            // disable lazy loading
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
