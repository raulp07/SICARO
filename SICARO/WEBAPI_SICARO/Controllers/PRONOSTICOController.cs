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
    public class PRONOSTICOController : ApiController
    {
        public IEnumerable<PRONOSTICO_EL> GET(PRONOSTICO_EL value)
        {
            return PRONOSTICO_DA.Accion.GetPRONOSTICOAll(value);
        }

        public int POST(PRONOSTICO_EL value)
        {
            return PRONOSTICO_DA.Accion.InsertPRONOSTICO(value);
        }

        // PUT api/values/5
        public int Put(int id,PRONOSTICO_EL value)
        {
            return PRONOSTICO_DA.Accion.UpdatePRONOSTICO(value);
        }
    }
}
