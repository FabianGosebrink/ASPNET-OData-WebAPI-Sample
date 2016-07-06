using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_WebAPI_OData_Sample.Models
{
    public class HouseDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public virtual ICollection<PersonDto> Persons { get; set; }
    }
}
