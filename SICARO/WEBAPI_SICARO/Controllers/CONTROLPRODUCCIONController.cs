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
    [RoutePrefix("api/CONTROLPRODUCCION")]
    public class CONTROLPRODUCCIONController : ApiController
    {
        [HttpGet]
        public IEnumerable<CONTROLPRODUCCION_EL> GET(int value, int value2, int value3, int value4, int value5, int value6)
        {
            return CONTROLPRODUCCION_DA.Accion.GetCONTROLPRODUCCIONAll(value, value2, value3, value4, value5, value6);
        }

        [HttpPost]
        public int POST(CONTROLPRODUCCION_EL value)
        {
            return CONTROLPRODUCCION_DA.Accion.InsertCONTROLPRODUCCION(value);
        }

        [HttpPut]
        public int Put(int id, CONTROLPRODUCCION_EL value)
        {
            return CONTROLPRODUCCION_DA.Accion.UpdateCONTROLPRODUCCION(value);
        }
        [HttpGet]
        [Route("ActualizarColor")]
        public int ActualizarColor()
        {
            return CONTROLPRODUCCION_DA.Accion.UpdateCONTROLPRODUCCIONcolor();
        }
    }
}
