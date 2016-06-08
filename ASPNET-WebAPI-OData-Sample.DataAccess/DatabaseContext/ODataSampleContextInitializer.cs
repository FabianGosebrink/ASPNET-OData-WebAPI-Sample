using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_WebAPI_OData_Sample.DataAccess.DatabaseContext
{
    public class ODataSampleContextInitializer : DropCreateDatabaseAlways<ODataSampleContext>
    {
        //TODO Override Seed here
        protected override void Seed(ODataSampleContext context)
        {
            base.Seed(context);
        }
    }
}
