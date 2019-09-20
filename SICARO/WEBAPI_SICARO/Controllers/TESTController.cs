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
    [RoutePrefix("api/TEST")]
    public class TESTController : ApiController
    {
        [HttpGet]
        public IEnumerable<TEST_EL> GET(int value)
        {
            return TEST_DA.Accion.GetAllTEST(value);
        }

        [HttpPost]
        public int POST(TEST_EL value)
        {
            return TEST_DA.Accion.InsertTEST(value);
        }

        [HttpPut]
        public int Put(int id,TEST_EL value)
        {
            return TEST_DA.Accion.UpdateTEST(value);
        }
    }
}
