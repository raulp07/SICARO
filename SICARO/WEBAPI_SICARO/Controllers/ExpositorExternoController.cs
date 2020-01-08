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
    [RoutePrefix("api/ExpositorExterno")]
    public class ExpositorExternoController : ApiController
    {
        [HttpGet]
        public IEnumerable<ExpositorExterno_EL> GET(int value)
        {
            return ExpositorExterno_DA.Accion.List_ExpositorExterno(value);
        }

        [HttpPost]
        public int POST(ExpositorExterno_EL value)
        {
            return ExpositorExterno_DA.Accion.CRUDExpositorExterno(value);
        }
    }
}
