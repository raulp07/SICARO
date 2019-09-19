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
    public class CONTROLPRODUCCIONController : ApiController
    {
        public IEnumerable<CONTROLPRODUCCION_EL> GET(CONTROLPRODUCCION_EL value)
        {
            return CONTROLPRODUCCION_DA.Accion.GetCONTROLPRODUCCIONAll(value);
        }
        
        public int POST(CONTROLPRODUCCION_EL value)
        {
            return CONTROLPRODUCCION_DA.Accion.InsertCONTROLPRODUCCION(value);
        }

        // PUT api/values/5
        public int Put(int id,CONTROLPRODUCCION_EL value)
        {
            return CONTROLPRODUCCION_DA.Accion.UpdateCONTROLPRODUCCION(value);
        }

    }
}
