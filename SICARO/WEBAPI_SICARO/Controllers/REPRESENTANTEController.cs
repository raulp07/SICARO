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
    public class REPRESENTANTEController : ApiController
    {
        public IEnumerable<REPRESENTANTE_EL> GET(REPRESENTANTE_EL value)
        {
            return REPRESENTANTE_DA.Accion.GetAllREPRESENTANTE(value);
        }

        public int POST(REPRESENTANTE_EL value)
        {
            return REPRESENTANTE_DA.Accion.InsertREPRESENTANTE(value);
        }

        // PUT api/values/5
        public int Put(int id,REPRESENTANTE_EL value)
        {
            return REPRESENTANTE_DA.Accion.UpdateREPRESENTANTE(value);
        }
    }
}
