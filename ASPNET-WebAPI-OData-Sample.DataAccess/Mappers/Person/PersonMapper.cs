using ASPNET_WebAPI_OData_Sample.Models;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Mappers.Person
{
    public class PersonMapper : IPersonMapper
    {
        public PersonDto Map(PersonEntity personEntity)
        {
            return new PersonDto()
            {

            };
        }

        public PersonEntity Map(PersonDto personDto)
        {
            return new PersonEntity();
        }
    }
}