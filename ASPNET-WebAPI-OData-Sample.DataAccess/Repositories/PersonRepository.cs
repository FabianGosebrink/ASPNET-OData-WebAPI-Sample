using System.Collections.Generic;
using System.Linq;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        readonly List<PersonEntity> _persons = new List<PersonEntity>();

        public IQueryable<PersonEntity> GetAll()
        {
            return _persons.AsQueryable();
        }

        public IQueryable<PersonEntity> GetSingle(int id)
        {
            return _persons.Where(x => x.Id == id).AsQueryable();
        }

        public PersonEntity Add(PersonEntity toAdd)
        {
            int newId = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;
            toAdd.Id = newId;
            _persons.Add(toAdd);
            return toAdd;
        }

        public PersonEntity Update(PersonEntity toUpdate)
        {
            PersonEntity single = _persons.FirstOrDefault(x => x.Id == toUpdate.Id);

            if (single == null)
            {
                return null;
            }

            _persons[single.Id] = toUpdate;
            return toUpdate;
        }

        public void Delete(int id)
        {
            PersonEntity single = _persons.FirstOrDefault(x => x.Id == id);
            _persons.Remove(single);
        }
    }
}
