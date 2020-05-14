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
    [RoutePrefix("api/CAPACITACION_PERSONAL")]
    public class CAPACITACION_PERSONALController : ApiController
    {
        [HttpGet]
        public IEnumerable<CAPACITACION_PERSONAL_EL> GET()
        {
            return CAPACITACION_PERSONAL_DA.Accion.GetAllCAPACITACION_PERSONAL();
        }

        [HttpGet]
        [Route("GETCAPACITACION_PERSONAL")]
        public IEnumerable<CAPACITACION_PERSONAL_EL> GET(int value, int value2, int value3)
        {
            return CAPACITACION_PERSONAL_DA.Accion.GetAllCAPACITACION_PERSONAL(value, value2, value3);
        }

        [HttpPost]
        public int POST(CAPACITACION_PERSONAL_EL value)
        {
            return CAPACITACION_PERSONAL_DA.Accion.InsertCAPACITACION_PERSONAL(value);
        }

        [HttpPut]
        public int Put(int id, CAPACITACION_PERSONAL_EL value)
        {
            return CAPACITACION_PERSONAL_DA.Accion.UpdateCAPACITACION_PERSONAL(value);
        }

        [HttpPost]
        [Route("RegistrarAsistencia")]
        public int RegistrarAsistencia(List<CAPACITACION_PERSONAL_EL> value)
        {
            return CAPACITACION_PERSONAL_DA.Accion.RegistrarAsistencia(value);
        }

        [HttpGet]
        [Route("GETOPERADORCORREO")]
        public string GETOPERADORCORREO(int value)
        {
            return CAPACITACION_PERSONAL_DA.Accion.GETOPERADORCORREO(value);
        }
    }
}
