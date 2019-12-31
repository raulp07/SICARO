using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_SICARO.Models;
using WEBAPI_SICARO.Persistencia;

namespace WEBAPI_SICARO.Controllers
{
    [RoutePrefix("api/PROVEEDOR_MATERIAPRIMA")]
    public class PROVEEDOR_MATERIAPRIMAController : ApiController
    {
        [HttpGet]
        public IEnumerable<PROVEEDOR_MATERIAPRIMA_EL> GET(int value,int value2)
        {
            return PROVEEDOR_MATERIAPRIMA_DA.Accion.Sel_PROVEEDOR_MATERIAPRIMA(value, value2);
        }
        
        [HttpPost]
        public int POST(PROVEEDOR_MATERIAPRIMA_EL value)
        {
            return PROVEEDOR_MATERIAPRIMA_DA.Accion.Ins_PROVEEDOR_MATERIAPRIMA(value);
        }

        //[HttpPut]
        //public int Put(int id, PROVEEDOR_MATERIAPRIMA_EL value)
        //{
        //    return PROVEEDOR_MATERIAPRIMA_DA.Accion.UpdateCAPACITACION(value);
        //}
    }
}
