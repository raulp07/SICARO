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
    [RoutePrefix("api/PROVEEDOR")]
    public class PROVEEDORController : ApiController
    {
        [HttpGet]
        public IEnumerable<PROVEEDOR_EL> GET(int value)
        {
            return PROVEEDOR_DA.Accion.GetAllPROVEEDOR(value);
        }

        [HttpPost]
        public int POST(PROVEEDOR_EL value)
        {
            return PROVEEDOR_DA.Accion.InsertPROVEEDOR(value);
        }

        [HttpPut]
        public int Put(int id,PROVEEDOR_EL value)
        {
            return PROVEEDOR_DA.Accion.UpdatePROVEEDOR(value);
        }
    }
}
