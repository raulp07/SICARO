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
    public class EVALUACION_PROVEEDORController : ApiController
    {
        public IEnumerable<EVALUACION_PROVEEDOR_EL> GET(EVALUACION_PROVEEDOR_EL value)
        {
            return EVALUACION_PROVEEDOR_DA.Accion.GetAllEVALUACION_PROVEEDOR(value);
        }

        public int POST(EVALUACION_PROVEEDOR_EL value)
        {
            return EVALUACION_PROVEEDOR_DA.Accion.InsertEVALUACION_PROVEEDOR(value);
        }

        // PUT api/values/5
        public int Put(int id,EVALUACION_PROVEEDOR_EL value)
        {
            return EVALUACION_PROVEEDOR_DA.Accion.UpdateEVALUACION_PROVEEDOR(value);
        }
    }
}
