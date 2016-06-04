using System.Collections.Generic;
using ASPNET_WebAPI_OData_Sample.Models.Models;

namespace ASPNET_WebAPI_OData_Sample.DataAccess
{
    public interface IPersonRepository
    {
        List<PersonEntity> GetAll();
        PersonEntity GetSingle(int id);
        PersonEntity Add(PersonEntity toAdd);
        PersonEntity Update(PersonEntity toUpdate);
        void Delete(int id);
    }
}