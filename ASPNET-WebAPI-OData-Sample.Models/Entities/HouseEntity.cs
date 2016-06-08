using System.Collections.Generic;

namespace ASPNET_WebAPI_OData_Sample.Models.Models
{
    public class HouseEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public ICollection<PersonEntity> Persons { get; set; }
    }
}