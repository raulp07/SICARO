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
    [RoutePrefix("api/MATERIA_PRIMA")]
    public class MATERIA_PRIMAController : ApiController
    {
        [HttpGet]
        public IEnumerable<MATERIA_PRIMA_EL> GET(int value)
        {
            return MATERIA_PRIMA_DA.Accion.GetAllMATERIA_PRIMA(value);
        }

        [HttpPost]
        public int POST(MATERIA_PRIMA_EL value)
        {
            return MATERIA_PRIMA_DA.Accion.InsertMATERIA_PRIMA(value);
        }

        [HttpPut]
        public int Put(int id,MATERIA_PRIMA_EL value)
        {
            return MATERIA_PRIMA_DA.Accion.UpdateMATERIA_PRIMA(value);
        }

        [HttpDelete]
        public int Delete(int value)
        {
            return MATERIA_PRIMA_DA.Accion.DeleteMATERIA_PRIMA(value);
        }
    }
}
