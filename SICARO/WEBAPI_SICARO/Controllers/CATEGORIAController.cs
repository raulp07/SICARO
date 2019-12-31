using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_SICARO.Models;
using WEBAPI_SICARO.Persistencia;

namespace WEBAPI_SICARO.Controllers
{
    [RoutePrefix("api/CATEGORIA")]
    public class CATEGORIAController : ApiController
    {
        [HttpGet]
        public IEnumerable<CATEGORIA_EL> GET(int value)
        {
            return CATEGORIA_DA.Accion.GetAllCATEGORIA(value);
        }

        [HttpPost]
        [Route("CategoriaRango")]
        public int CategoriaRango(CATEGORIA_EL value)
        {
            return CATEGORIA_DA.Accion.UpdateCategoriaRango(value);
        }

        
    }
}
