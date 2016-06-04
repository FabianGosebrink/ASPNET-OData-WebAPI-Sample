using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using ASPNET_WebAPI_OData_Sample.DataAccess;

namespace ASPNET_WebAPI_OData_Sample.Controllers
{
    public class HouseController : ODataController
    {
        private readonly IHouseRepository _houseRepository;

        public HouseController()
        {
            _houseRepository = new HouseRepository();
        }

        [HttpGet]
        [ODataRoute("Houses")]
        public IHttpActionResult GetAllHouses()
        {
            return Ok(_houseRepository.GetAll());
        }

        [HttpGet]
        [ODataRoute("Houses({id})")]
        public IHttpActionResult GetSingleHouse([FromODataUri] int id)
        {
            var house = _houseRepository.GetSingle(id);

            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }
    }
}
