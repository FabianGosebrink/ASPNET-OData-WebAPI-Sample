using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using ASPNET_WebAPI_OData_Sample.DataAccess;
using ASPNET_WebAPI_OData_Sample.DataAccess.Repositories;

namespace ASPNET_WebAPI_OData_Sample.Controllers
{
    public class PersonController : ODataController
    {
        private readonly IPersonRepository _personRepository;

        public PersonController()
        {
            _personRepository = new PersonRepository();
        }

        [HttpGet]
        [ODataRoute("Persons")]
        public IHttpActionResult GetAllPersons()
        {
            return Ok(_personRepository.GetAll());
        }

        [HttpGet]
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
    }
}
