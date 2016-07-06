using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNET_WebAPI_OData_Sample.Models;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Mappers.House
{
    public interface IHouseMapper
    {
        HouseDto Map(HouseEntity houseEntity);
        HouseEntity Map(HouseDto houseDto);
    }
}
