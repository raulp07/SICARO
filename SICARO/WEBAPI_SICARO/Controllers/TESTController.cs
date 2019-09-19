using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_SICARO.Modles;
using WEBAPI_SICARO.Persistencia;
namespace WEBAPI_SICARO.Controllers
{
    public class TESTController : ApiController
    {
        public IEnumerable<TEST_EL> GET(TEST_EL value)
        {
            return TEST_DA.Accion.GetAllTEST(value);
        }

        public int POST(TEST_EL value)
        {
            return TEST_DA.Accion.InsertTEST(value);
        }

        // PUT api/values/5
        public int Put(int id,TEST_EL value)
        {
            return TEST_DA.Accion.UpdateTEST(value);
        }
    }
}
