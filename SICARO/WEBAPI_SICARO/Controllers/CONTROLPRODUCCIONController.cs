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
        public IEnumerable<CONTROLPRODUCCION_EL> GET(int value)
        {
            return CONTROLPRODUCCION_DA.Accion.GetCONTROLPRODUCCIONAll(value);
        }
        
        [HttpPost]
        public int POST(CONTROLPRODUCCION_EL value)
        {
            return CONTROLPRODUCCION_DA.Accion.InsertCONTROLPRODUCCION(value);
        }

        [HttpPut]
        public int Put(int id,CONTROLPRODUCCION_EL value)
        {
            return CONTROLPRODUCCION_DA.Accion.UpdateCONTROLPRODUCCION(value);
        }

    }
}
