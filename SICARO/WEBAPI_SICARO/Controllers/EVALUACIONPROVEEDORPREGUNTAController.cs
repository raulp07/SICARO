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
    [RoutePrefix("api/EVALUACIONPROVEEDORPREGUNTA")]
    public class EVALUACIONPROVEEDORPREGUNTAController : ApiController
    {
        [HttpGet]
        public IEnumerable<EVALUACIONPROVEEDORPREGUNTA_EL> GET(int value)
        {
            return EVALUACIONPROVEEDORPREGUNTA_DA.Accion.GetAllEVALUACIONPROVEEDORPREGUNTA(value);
        }

        [HttpPost]
        public int POST(EVALUACIONPROVEEDORPREGUNTA_EL value)
        {
            return EVALUACIONPROVEEDORPREGUNTA_DA.Accion.InsertEVALUACIONPROVEEDORPREGUNTA(value);
        }

        [HttpPut]
        public int Put(int id,EVALUACIONPROVEEDORPREGUNTA_EL value)
        {
            return EVALUACIONPROVEEDORPREGUNTA_DA.Accion.UpdateEVALUACIONPROVEEDORPREGUNTA(value);
        }
    }
}
