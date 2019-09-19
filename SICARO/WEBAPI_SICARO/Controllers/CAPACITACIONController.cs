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
    public class CAPACITACIONController : ApiController
    {
        public IEnumerable<CAPACITACION_EL> GET()
        {
            return CAPACITACION_DA.Accion.GetAllCAPACITACION1();
        }

        public CAPACITACION_EL GET(int DA)
        {
            return CAPACITACION_DA.Accion.GetAllCAPACITACION(DA);
        }
        
        public int POST(CAPACITACION_EL value)
        {
            return CAPACITACION_DA.Accion.InsertCAPACITACION(value);
        }

        // PUT api/values/5
        public int Put(int id,CAPACITACION_EL value)
        {
            return CAPACITACION_DA.Accion.UpdateCAPACITACION(value);
        }
        
    }
}
