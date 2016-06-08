using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ASPNET_WebAPI_OData_Sample.DataAccess.DatabaseContext;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ODataSampleContext _context = new ODataSampleContext();

        public IQueryable<PersonEntity> GetAll()
        {
            return _context.Persons.AsQueryable();
        }

        public IQueryable<PersonEntity> GetSingle(int id)
        {
            return _context.Persons.Where(x => x.Id == id).AsQueryable();
        }

        public PersonEntity Add(PersonEntity toAdd)
        {
            _context.Persons.Add(toAdd);
            return toAdd;
        }

        public PersonEntity Update(PersonEntity toUpdate)
        {
            PersonEntity single = _context.Persons.FirstOrDefault(x => x.Id == toUpdate.Id);

            if (single == null)
            {
                return null;
            }

            _context.Persons.AddOrUpdate(toUpdate);
            return toUpdate;
        }

        public void Delete(int id)
        {
            PersonEntity single = _context.Persons.FirstOrDefault(x => x.Id == id);
            _context.Persons.Remove(single);
        }

        public void SaveToDb()
        {
            _context.SaveChanges();
        }
    }
}
