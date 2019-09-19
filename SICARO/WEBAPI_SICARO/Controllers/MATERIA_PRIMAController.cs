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
    public class MATERIA_PRIMAController : ApiController
    {
        public IEnumerable<MATERIA_PRIMA_EL> GET(MATERIA_PRIMA_EL value)
        {
            return MATERIA_PRIMA_DA.Accion.GetAllMATERIA_PRIMA(value);
        }

        public int POST(MATERIA_PRIMA_EL value)
        {
            return MATERIA_PRIMA_DA.Accion.InsertMATERIA_PRIMA(value);
        }

        // PUT api/values/5
        public int Put(int id,MATERIA_PRIMA_EL value)
        {
            return MATERIA_PRIMA_DA.Accion.UpdateMATERIA_PRIMA(value);
        }
    }
}
