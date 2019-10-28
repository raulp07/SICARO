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
    [RoutePrefix("api/PERSONAL")]
    public class PERSONALController : ApiController
    {
        [HttpGet]
        public IEnumerable<PERSONAL_EL> GET(int value)
        {
            return PERSONAL_DA.Accion.GetAllPERSONAL(value);
        }

        [HttpPost]
        [Route("PERSONAL")]
        public IEnumerable<PERSONAL_EL> GETPersonal(int value)
        {
            return PERSONAL_DA.Accion.GetAllPERSONAL(value);
        }

        [HttpPost]
        public int POST(PERSONAL_EL value)
        {
            return PERSONAL_DA.Accion.InsertPERSONAL(value);
        }

        [HttpPut]
        public int Put(int id,PERSONAL_EL value)
        {
            return PERSONAL_DA.Accion.UpdatePERSONAL(value);
        }
    }
}
