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
    public class PROVEEDORController : ApiController
    {
        public IEnumerable<PROVEEDOR_EL> GET(PROVEEDOR_EL value)
        {
            return PROVEEDOR_DA.Accion.GetAllPROVEEDOR(value);
        }

        public int POST(PROVEEDOR_EL value)
        {
            return PROVEEDOR_DA.Accion.InsertPROVEEDOR(value);
        }

        // PUT api/values/5
        public int Put(int id,PROVEEDOR_EL value)
        {
            return PROVEEDOR_DA.Accion.UpdatePROVEEDOR(value);
        }
    }
}
