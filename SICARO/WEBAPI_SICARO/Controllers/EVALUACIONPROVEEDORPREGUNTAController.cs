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
    public class EVALUACIONPROVEEDORPREGUNTAController : ApiController
    {

        public IEnumerable<EVALUACIONPROVEEDORPREGUNTA_EL> GET(EVALUACIONPROVEEDORPREGUNTA_EL value)
        {
            return EVALUACIONPROVEEDORPREGUNTA_DA.Accion.GetAllEVALUACIONPROVEEDORPREGUNTA(value);
        }

        public int POST(EVALUACIONPROVEEDORPREGUNTA_EL value)
        {
            return EVALUACIONPROVEEDORPREGUNTA_DA.Accion.InsertEVALUACIONPROVEEDORPREGUNTA(value);
        }

        // PUT api/values/5
        public int Put(int id,EVALUACIONPROVEEDORPREGUNTA_EL value)
        {
            return EVALUACIONPROVEEDORPREGUNTA_DA.Accion.UpdateEVALUACIONPROVEEDORPREGUNTA(value);
        }
    }
}
