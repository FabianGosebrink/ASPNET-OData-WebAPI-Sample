using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ASPNET_WebAPI_OData_Sample.DataAccess.DatabaseContext;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly ODataSampleContext _context = new ODataSampleContext();

        public IQueryable<HouseEntity> GetAll()
        {
            return _context.Houses.AsQueryable();
        }

        public IQueryable<HouseEntity> GetSingle(int id)
        {
            return _context.Houses.Where(x => x.Id == id).AsQueryable();
        }

        public HouseEntity Add(HouseEntity toAdd)
        {
            _context.Houses.Add(toAdd);
            return toAdd;
        }

        public HouseEntity Update(HouseEntity toUpdate)
        {
            HouseEntity single = _context.Houses.FirstOrDefault(x => x.Id == toUpdate.Id);

            if (single == null)
            {
                return null;
            }

            _context.Houses.AddOrUpdate(toUpdate);
            return toUpdate;
        }

        public void Delete(int id)
        {
            HouseEntity single = _context.Houses.FirstOrDefault(x => x.Id == id);
            _context.Houses.Remove(single);
        }

        public void SaveToDb()
        {
            _context.SaveChanges();
        }
    }
}