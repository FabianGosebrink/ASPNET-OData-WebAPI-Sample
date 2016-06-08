using System.Linq;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Repositories
{
    public interface IPersonRepository
    {
        IQueryable<PersonEntity> GetAll();
        IQueryable<PersonEntity> GetSingle(int id);
        PersonEntity Add(PersonEntity toAdd);
        PersonEntity Update(PersonEntity toUpdate);
        void Delete(int id);
        void SaveToDb();
    }
}