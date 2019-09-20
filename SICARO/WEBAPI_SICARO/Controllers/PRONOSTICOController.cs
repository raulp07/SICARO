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
    [RoutePrefix("api/PRONOSTICO")]
    public class PRONOSTICOController : ApiController
    {
        [HttpGet]
        public IEnumerable<PRONOSTICO_EL> GET(int value)
        {
            return PRONOSTICO_DA.Accion.GetPRONOSTICOAll(value);
        }

        [HttpPost]
        public int POST(PRONOSTICO_EL value)
        {
            return PRONOSTICO_DA.Accion.InsertPRONOSTICO(value);
        }

        [HttpPut]
        public int Put(int id,PRONOSTICO_EL value)
        {
            return PRONOSTICO_DA.Accion.UpdatePRONOSTICO(value);
        }
    }
}
