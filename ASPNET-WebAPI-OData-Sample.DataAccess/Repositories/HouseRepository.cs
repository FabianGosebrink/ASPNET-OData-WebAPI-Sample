using System.Collections.Generic;
using System.Linq;
using ASPNET_WebAPI_OData_Sample.Models.Models;

namespace ASPNET_WebAPI_OData_Sample.DataAccess
{
    public class HouseRepository : IHouseRepository
    {
        readonly List<HouseEntity> _houses = new List<HouseEntity>();

        public HouseRepository()
        {
            _houses.Add(new HouseEntity() { City = "Town1", Id = 1, Street = "Street1", ZipCode = 1234 });
            _houses.Add(new HouseEntity() { City = "Town2", Id = 2, Street = "Street2", ZipCode = 1234 });
            _houses.Add(new HouseEntity() { City = "Town3", Id = 3, Street = "Street3", ZipCode = 1234 });
            _houses.Add(new HouseEntity() { City = "Town4", Id = 4, Street = "Street4", ZipCode = 1234 });
        }

        public IQueryable<HouseEntity> GetAll()
        {
            return _houses.AsQueryable();
        }

        public IQueryable<HouseEntity> GetSingle(int id)
        {
            return _houses.Where(x => x.Id == id).AsQueryable();
        }

        public HouseEntity Add(HouseEntity toAdd)
        {
            int newId = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;
            toAdd.Id = newId;
            _houses.Add(toAdd);
            return toAdd;
        }

        public HouseEntity Update(HouseEntity toUpdate)
        {
            HouseEntity single = _houses.FirstOrDefault(x => x.Id == toUpdate.Id);

            if (single == null)
            {
                return null;
            }

            _houses[single.Id] = toUpdate;
            return toUpdate;
        }

        public void Delete(int id)
        {
            HouseEntity single = _houses.FirstOrDefault(x => x.Id == id);
            _houses.Remove(single);
        }
    }
}