using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_WebAPI_OData_Sample.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Prename { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        
        public HouseDto House { get; set; }
    }
}
