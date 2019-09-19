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
    public class DETALLE_CAPACITACION_PERSONALController : ApiController
    {

        public IEnumerable<DETALLE_CAPACITACION_PERSONAL_EL> GET(DETALLE_CAPACITACION_PERSONAL_EL value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.GetAllDETALLECAPACITACIONPERSONAL(value);
        }

        public int POST(DETALLE_CAPACITACION_PERSONAL_EL value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.InsertDETALLE_CAPACITACION_PERSONAL(value);
        }

        // PUT api/values/5
        public int Put(int id,DETALLE_CAPACITACION_PERSONAL_EL value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.UpdateDETALLE_CAPACITACION_PERSONAL(value);
        }
    }
}
