using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using ASPNET_WebAPI_OData_Sample.DataAccess.Repositories;
using ASPNET_WebAPI_OData_Sample.Models.Entities;

namespace ASPNET_WebAPI_OData_Sample.Controllers
{
    public class PersonController : ODataController
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Persons")]
        public IHttpActionResult GetAllPersons()
        {
            return Ok(_personRepository.GetAll());
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Persons({id})")]
        public IHttpActionResult GetSinglePerson([FromODataUri] int id)
        {
            var personEntity = _personRepository.GetSingle(id);

            if (personEntity == null)
            {
                return NotFound();
            }

            return Ok(SingleResult.Create(personEntity));
        }

        [HttpPost]
        [ODataRoute("Persons")]
        public IHttpActionResult CreateNewPerson(PersonEntity personEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonEntity addedEntity = _personRepository.Add(personEntity);
            _personRepository.SaveToDb();

            return Created(addedEntity);
        }

        [HttpPut]
        [ODataRoute("Persons({id})")]
        public IHttpActionResult UpdateFullPerson([FromODataUri] int id, PersonEntity personEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonEntity existingPersonEntity = _personRepository.GetSingle(id).First();

            if (existingPersonEntity == null)
            {
                return NotFound();
            }

            personEntity.Id = existingPersonEntity.Id;

            _personRepository.Update(personEntity);
            _personRepository.SaveToDb();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [ODataRoute("Persons({id})")]
        public IHttpActionResult Patch([FromODataUri] int id, Delta<PersonEntity> personEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonEntity existingPersonEntity = _personRepository.GetSingle(id).First();

            if (existingPersonEntity == null)
            {
                return NotFound();
            }

            personEntity.Patch(existingPersonEntity);
            _personRepository.SaveToDb();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ODataRoute("Persons({id})")]
        public IHttpActionResult Delete([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PersonEntity existingPersonEntity = _personRepository.GetSingle(id).First();

            if (existingPersonEntity == null)
            {
                return NotFound();
            }

            _personRepository.Delete(id);
            _personRepository.SaveToDb();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
