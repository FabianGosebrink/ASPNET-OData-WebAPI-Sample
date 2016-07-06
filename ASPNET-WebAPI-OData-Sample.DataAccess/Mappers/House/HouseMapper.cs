using System.Collections.Generic;
using System.Linq;
using ASPNET_WebAPI_OData_Sample.DataAccess.Mappers.Person;
using ASPNET_WebAPI_OData_Sample.Models;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Mappers.House
{
    public class HouseMapper : IHouseMapper
    {
        private readonly IPersonMapper _personMapper;

        public HouseMapper(IPersonMapper personMapper)
        {
            _personMapper = personMapper;
        }

        public HouseDto Map(HouseEntity houseEntity)
        {
            return new HouseDto()
            {
                City = houseEntity.City,
                Street = houseEntity.Street,
                ZipCode = houseEntity.ZipCode,
                Persons = houseEntity.Persons?.Select(x=> _personMapper.Map(x)).ToList() ?? new List<PersonDto>(),
                Id = houseEntity.Id
            };
        }

        public HouseEntity Map(HouseDto houseDto)
        {
            return new HouseEntity()
            {
                City = houseDto.City,
                Street = houseDto.Street,
                ZipCode = houseDto.ZipCode,
                Persons = houseDto.Persons?.Select(x => _personMapper.Map(x)).ToList() ?? new List<PersonEntity>(),
                Id = houseDto.Id
            };
        }
    }
}