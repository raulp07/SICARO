using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPI_SICARO.Modles;
using WEBAPI_SICARO.Persistencia;

namespace WEBAPI_SICARO.Controllers
{
    public class CAPACITACION_PERSONALController : ApiController
    {
        public IEnumerable<CAPACITACION_PERSONAL_EL> GET()
        {
            return CAPACITACION_PERSONAL_DA.Accion.GetAllCAPACITACION_PERSONAL();
        }
        public IEnumerable<CAPACITACION_PERSONAL_EL> GET(int id)
        {
            return CAPACITACION_PERSONAL_DA.Accion.GetAllCAPACITACION_PERSONAL(id);
        }

        public int POST(CAPACITACION_PERSONAL_EL value)
        {
            return CAPACITACION_PERSONAL_DA.Accion.InsertCAPACITACION_PERSONAL(value);
        }

        // PUT api/values/5
        public int Put(int id, CAPACITACION_PERSONAL_EL value)
        {
            return CAPACITACION_PERSONAL_DA.Accion.UpdateCAPACITACION_PERSONAL(value);
        }

    }
}
