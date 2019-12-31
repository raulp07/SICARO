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
    [RoutePrefix("api/OPCION")]
    public class OPCIONController : ApiController
    {
        [HttpGet]
        public Opcion_EL GET(int value)
        {
            return OPCION_DA.Opcion.GetOpcionByID(value);
        }

        [HttpGet]
        [Route("GETOPCION")]
        public IEnumerable<Opcion_EL> GETOPCION(int value)
        {
            return OPCION_DA.Opcion.GETOPCION(value);
        }

        public int POST(Opcion_EL value)
        {
            return OPCION_DA.Opcion.InsertOpcion(value);
        }

        //// PUT api/values/5
        //public int Put(int id,OPCION_EL value)
        //{
        //    return OPCION_DA.Accion.UpdateOPCION(value);
        //}
    }
}
