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
    public class OPCION_PREGUNTAController : ApiController
    {
        public IEnumerable<OPCION_PREGUNTA_EL> GET(OPCION_PREGUNTA_EL value)
        {
            return OPCION_PREGUNTA_DA.Accion.GetAllOPCION_PREGUNTA(value);
        }

        public int POST(OPCION_PREGUNTA_EL value)
        {
            return OPCION_PREGUNTA_DA.Accion.InsertOPCION_PREGUNTA(value);
        }

        // PUT api/values/5
        public int Put(int id,OPCION_PREGUNTA_EL value)
        {
            return OPCION_PREGUNTA_DA.Accion.UpdateOPCION_PREGUNTA(value);
        }
    }
}
