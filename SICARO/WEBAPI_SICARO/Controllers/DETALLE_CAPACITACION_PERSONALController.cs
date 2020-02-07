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
    [RoutePrefix("api/DETALLE_CAPACITACION_PERSONAL")]
    public class DETALLE_CAPACITACION_PERSONALController : ApiController
    {
        [HttpGet]
        public IEnumerable<DETALLE_CAPACITACION_PERSONAL_EL> GET(int value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.GetAllDETALLECAPACITACIONPERSONAL(value);
        }

        [HttpPost]
        public int POST(IEnumerable<DETALLE_CAPACITACION_PERSONAL_EL> value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.InsertDETALLE_CAPACITACION_PERSONAL(value);
        }

        [HttpPut]
        public int Put(int id,DETALLE_CAPACITACION_PERSONAL_EL value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.UpdateDETALLE_CAPACITACION_PERSONAL(value);
        }
    }
}
