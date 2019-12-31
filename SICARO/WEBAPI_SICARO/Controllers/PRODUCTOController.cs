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
    [RoutePrefix("api/PRODUCTO")]
    public class PRODUCTOController : ApiController
    {
        [HttpGet]
        public IEnumerable<PRODUCTO_EL> GET(int value)
        {
            return PRODUCTO_DA.Accion.GetAllPRODUCTO(value);
        }
        
        [HttpPost]
        public int POST(PRODUCTO_EL value)
        {
            return PRODUCTO_DA.Accion.InsertPRODUCTO(value);
        }

        [HttpPut]
        public int Put(int id, PRODUCTO_EL value)
        {
            return PRODUCTO_DA.Accion.UpdatePRODUCTO(value);
        }
    }
}
