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
    [RoutePrefix("api/GESTION_CAPACITACION")]
    public class GESTION_CAPACITACIONController : ApiController
    { 
        [HttpGet]
        public IEnumerable<GESTION_CAPACITACION_EL> GET(int value)
        {
            return GESTION_CAPACITACION_DA.Accion.GetAllGESTION_CAPACITACION(value);
        }

        [HttpPost]
        public int POST(GESTION_CAPACITACION_EL value)
        {
            return GESTION_CAPACITACION_DA.Accion.InsertGESTION_CAPACITACION(value);
        }

        [HttpPut]
        public int Put(int id,GESTION_CAPACITACION_EL value)
        {
            return GESTION_CAPACITACION_DA.Accion.UpdateGESTION_CAPACITACION(value);
        }
    }
}
