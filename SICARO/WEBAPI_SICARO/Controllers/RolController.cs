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
    [RoutePrefix("api/Rol")]
    public class RolController : ApiController
    {
        [HttpGet]
        public IEnumerable<Rol_EL> GET(int value)
        {
            return Rol_DA.Accion.GetAllRol(value);
        }

        [HttpPost]
        public int POST(Rol_EL value)
        {
            return Rol_DA.Accion.InsertRol(value);
        }
        
        //[HttpPut]
        //public int Put(int id, Rol_EL value)
        //{
        //    return Rol_DA.Accion.UpdateCAPACITACION(value);
        //}
    }
}
