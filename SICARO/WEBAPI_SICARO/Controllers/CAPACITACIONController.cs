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
    [RoutePrefix("api/CAPACITACION")]
    public class CAPACITACIONController : ApiController
    {
        [HttpGet]
        public IEnumerable<CAPACITACION_EL> GET()
        {
            return CAPACITACION_DA.Accion.GetAllCAPACITACION1();
        }

        [HttpGet]
        public CAPACITACION_EL GET(int value)
        {
            return CAPACITACION_DA.Accion.GetAllCAPACITACION(value);
        }

        [HttpPost]
        public Respuesta POST(CAPACITACION_EL value)
        {
            return CAPACITACION_DA.Accion.InsertCAPACITACION(value);
        }

        [HttpPut]
        public Respuesta Put(int id,CAPACITACION_EL value)
        {
            return CAPACITACION_DA.Accion.UpdateCAPACITACION(value);
        }

        [HttpGet]
        [Route("CapacitacionTest")]
        public IEnumerable<CAPACITACION_EL> GETCapacitacionTest(int value)
        {
            return CAPACITACION_DA.Accion.GetAllCAPACITACION_TEST(value);
        }
        [HttpGet]
        [Route("FinalizarCapacitacion")]
        public int FinalizarCapacitacion(int value)
        {
            return CAPACITACION_DA.Accion.FinalizarCapacitacion(value);
        }
    }
}
