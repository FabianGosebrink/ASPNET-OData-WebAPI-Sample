using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using ASPNET_WebAPI_OData_Sample.DataAccess.Mappers.House;
using ASPNET_WebAPI_OData_Sample.DataAccess.Repositories;
using ASPNET_WebAPI_OData_Sample.Models;
using ASPNET_WebAPI_OData_Sample.Models.Entities;
using AutoMapper.QueryableExtensions;

namespace ASPNET_WebAPI_OData_Sample.Controllers
{
    public class HouseController : ODataController
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IHouseMapper _houseMapper;

        public HouseController(IHouseRepository houseRepository, IHouseMapper houseMapper)
        {
            _houseRepository = houseRepository;
            _houseMapper = houseMapper;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Houses")]
        public IHttpActionResult GetAllHouses()
        {
            return Ok(_houseRepository.GetAll().Select(x => _houseMapper.Map(x)).AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Houses({id})")]
        public IHttpActionResult GetSingleHouse([FromODataUri] int id)
        {
            IQueryable<HouseEntity> house = _houseRepository.GetAll().Where(x => x.Id == id);

            if (!house.Any())
            {
                return NotFound();
            }

            return Ok(SingleResult.Create(house));
        }

        [HttpPost]
        [ODataRoute("Houses")]
        public IHttpActionResult CreateNewHouse(HouseEntity houseEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HouseEntity addedEntity = _houseRepository.Add(houseEntity);
            _houseRepository.SaveToDb();

            return Created(addedEntity);
        }

        [HttpPut]
        [ODataRoute("Houses({id})")]
        public IHttpActionResult UpdateFullHouse([FromODataUri] int id, HouseEntity houseEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HouseEntity existingHouseEntity = _houseRepository.GetSingle(id).First();

            if (existingHouseEntity == null)
            {
                return NotFound();
            }

            houseEntity.Id = existingHouseEntity.Id;

            _houseRepository.Update(houseEntity);
            _houseRepository.SaveToDb();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [ODataRoute("Houses({id})")]
        public IHttpActionResult Patch([FromODataUri] int id, Delta<HouseEntity> houseEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HouseEntity existingHouseEntity = _houseRepository.GetSingle(id).First();

            if (existingHouseEntity == null)
            {
                return NotFound();
            }

            houseEntity.Patch(existingHouseEntity);
            _houseRepository.SaveToDb();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ODataRoute("Houses({id})")]
        public IHttpActionResult Delete([FromODataUri] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HouseEntity existingHouseEntity = _houseRepository.GetSingle(id).First();

            if (existingHouseEntity == null)
            {
                return NotFound();
            }

            _houseRepository.Delete(id);
            _houseRepository.SaveToDb();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
