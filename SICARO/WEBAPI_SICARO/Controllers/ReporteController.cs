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
    [RoutePrefix("api/Reporte")]
    public class ReporteController : ApiController
    {

        [HttpPost]
        [Route("ListarReporte")]
        public IEnumerable<Reporte_EL> ListarReporte(Reporte_EL value)
        {
            return Reporte_DA.Accion.GetReporteGeneral(value);
        }
    }
}
