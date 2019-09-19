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
    public class PREGUNTAController : ApiController
    {
        public IEnumerable<PREGUNTA_EL> GET(PREGUNTA_EL value)
        {
            return PREGUNTA_DA.Accion.GetAllPREGUNTA(value);
        }

        public int POST(PREGUNTA_EL value)
        {
            return PREGUNTA_DA.Accion.InsertPREGUNTA(value);
        }

        // PUT api/values/5
        public int Put(int id,PREGUNTA_EL value)
        {
            return PREGUNTA_DA.Accion.UpdatePREGUNTA(value);
        }
    }
}
