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
    [RoutePrefix("api/USUARIO")]
    public class USUARIOController : ApiController
    {
        [HttpPost]
        [Route("ValidarUsuario")]
        public IEnumerable<USUARIO_EL> ValidarUsuario(USUARIO_EL value)
        {
            return USUARIO_DA.Accion.GetAllUSUARIO(value);
        }

        [HttpPost]
        [Route("GestionarUsuario")]
        public int GestionarUsuario(USUARIO_EL value)
        {
            return USUARIO_DA.Accion.InsertUSUARIO(value);
        }

        //// PUT api/values/5
        //public int Put(int id,USUARIO_EL value)
        //{
        //    return USUARIO_DA.Accion.UpdateUSUARIO(value);
        //}
    }
}
