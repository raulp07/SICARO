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
    [RoutePrefix("api/OPCION_PREGUNTA")]
    public class OPCION_PREGUNTAController : ApiController
    {
        [HttpGet]
        public IEnumerable<OPCION_PREGUNTA_EL> GET(int value)
        {
            return OPCION_PREGUNTA_DA.Accion.GetAllOPCION_PREGUNTA(value);
        }

        [HttpPost]
        public int POST(OPCION_PREGUNTA_EL value)
        {
            return OPCION_PREGUNTA_DA.Accion.InsertOPCION_PREGUNTA(value);
        }

        [HttpPut]
        public int Put(int id,OPCION_PREGUNTA_EL value)
        {
            return OPCION_PREGUNTA_DA.Accion.UpdateOPCION_PREGUNTA(value);
        }

        [HttpGet]
        [Route("TESTPREGUNTAOPCION")]
        public IEnumerable<OPCION_PREGUNTA_EL> TESTPREGUNTAOPCION(int value,int value2=0)
        {
            return OPCION_PREGUNTA_DA.Accion.GetAllTestPreguntaOpcion(value,value2);
        }
        //GetAllTestPreguntaOpcion
    }
}
