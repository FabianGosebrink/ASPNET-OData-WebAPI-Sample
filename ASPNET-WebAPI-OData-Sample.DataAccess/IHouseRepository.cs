using System.Collections.Generic;
using ASPNET_WebAPI_OData_Sample.Models.Models;

namespace ASPNET_WebAPI_OData_Sample.DataAccess
{
    public interface IHouseRepository
    {
        List<HouseEntity> GetAll();
        HouseEntity GetSingle(int id);
        HouseEntity Add(HouseEntity toAdd);
        HouseEntity Update(HouseEntity toUpdate);
        void Delete(int id);
    }
}
