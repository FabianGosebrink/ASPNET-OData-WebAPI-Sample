using System.Linq;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Repositories
{
    public interface IHouseRepository
    {
        IQueryable<HouseEntity> GetAll();
        IQueryable<HouseEntity> GetSingle(int id);
        HouseEntity Add(HouseEntity toAdd);
        HouseEntity Update(HouseEntity toUpdate);
        void Delete(int id);
        void SaveToDb();
    }
}
