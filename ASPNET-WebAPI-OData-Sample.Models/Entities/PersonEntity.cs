namespace ASPNET_WebAPI_OData_Sample.Models.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Prename { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        
        public HouseEntity House { get; set; }
    }
}
