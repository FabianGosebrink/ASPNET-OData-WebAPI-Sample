using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.DatabaseContext
{
    public class ODataSampleContextInitializer : DropCreateDatabaseAlways<ODataSampleContext>
    {
        //TODO Override Seed here
        protected override void Seed(ODataSampleContext context)
        {
            context.Houses.Add(new HouseEntity() { City = "Town1", Id = 1, Street = "Street1", ZipCode = 1234,Persons = new List<PersonEntity>()
            {
                new PersonEntity() {Age = 30, Prename = "Fabian", Surname = "Gosebrink"}
            }});
            context.Houses.Add(new HouseEntity() { City = "Town2", Id = 2, Street = "Street2", ZipCode = 1234 });
            context.Houses.Add(new HouseEntity() { City = "Town3", Id = 3, Street = "Street3", ZipCode = 1234 });
            context.Houses.Add(new HouseEntity() { City = "Town4", Id = 4, Street = "Street4", ZipCode = 1234 });

            context.SaveChanges();
            
        }
    }
}
