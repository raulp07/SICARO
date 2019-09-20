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
    [RoutePrefix("api/REPRESENTANTE")]
    public class REPRESENTANTEController : ApiController
    {
        [HttpGet]
        public IEnumerable<REPRESENTANTE_EL> GET(int value)
        {
            return REPRESENTANTE_DA.Accion.GetAllREPRESENTANTE(value);
        }

        [HttpPost]
        public int POST(REPRESENTANTE_EL value)
        {
            return REPRESENTANTE_DA.Accion.InsertREPRESENTANTE(value);
        }

        [HttpPut]
        public int Put(int id,REPRESENTANTE_EL value)
        {
            return REPRESENTANTE_DA.Accion.UpdateREPRESENTANTE(value);
        }
    }
}
