using System.Collections.Generic;
using System.Linq;
using ASPNET_WebAPI_OData_Sample.Models.Models;

namespace ASPNET_WebAPI_OData_Sample.DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        readonly Dictionary<int, PersonEntity> _persons = new Dictionary<int, PersonEntity>();

        public List<PersonEntity> GetAll()
        {
            return _persons.Select(x => x.Value).ToList();
        }

        public PersonEntity GetSingle(int id)
        {
            return _persons.FirstOrDefault(x => x.Key == id).Value;
        }

        public PersonEntity Add(PersonEntity toAdd)
        {
            int newId = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;
            toAdd.Id = newId;
            _persons.Add(newId, toAdd);
            return toAdd;
        }

        public PersonEntity Update(PersonEntity toUpdate)
        {
            PersonEntity single = GetSingle(toUpdate.Id);

            if (single == null)
            {
                return null;
            }

            _persons[single.Id] = toUpdate;
            return toUpdate;
        }

        public void Delete(int id)
        {
            _persons.Remove(id);
        }
    }
}
