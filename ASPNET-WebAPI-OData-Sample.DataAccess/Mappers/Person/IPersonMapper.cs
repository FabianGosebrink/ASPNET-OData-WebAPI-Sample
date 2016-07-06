using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNET_WebAPI_OData_Sample.Models;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Mappers.Person
{
    public interface IPersonMapper
    {
        PersonDto Map(PersonEntity personEntity);
        PersonEntity Map(PersonDto personDto);
    }
}
