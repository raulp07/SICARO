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
    [RoutePrefix("api/EVALUACION_PROVEEDOR")]
    public class EVALUACION_PROVEEDORController : ApiController
    {
        [HttpGet]
        public IEnumerable<EVALUACION_PROVEEDOR_EL> GET(int value)
        {
            return EVALUACION_PROVEEDOR_DA.Accion.GetAllEVALUACION_PROVEEDOR(value);
        }

        [HttpPost]
        public int POST(EVALUACION_PROVEEDOR_EL value)
        {
            return EVALUACION_PROVEEDOR_DA.Accion.InsertEVALUACION_PROVEEDOR(value);
        }

        [HttpPut]
        public int Put(int id,EVALUACION_PROVEEDOR_EL value)
        {
            return EVALUACION_PROVEEDOR_DA.Accion.UpdateEVALUACION_PROVEEDOR(value);
        }
    }
}
