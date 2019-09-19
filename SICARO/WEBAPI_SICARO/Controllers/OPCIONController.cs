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
    public class OPCIONController : ApiController
    {
        public Opcion_EL GET(int value)
        {
            return OPCION_DA.Opcion.GetOpcionByID(value);
        }

        //public int POST(OPCION_EL value)
        //{
        //    return OPCION_DA.Accion.InsertOPCION(value);
        //}

        //// PUT api/values/5
        //public int Put(int id,OPCION_EL value)
        //{
        //    return OPCION_DA.Accion.UpdateOPCION(value);
        //}
    }
}
