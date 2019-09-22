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
    [RoutePrefix("api/TGeneral")]
    public class TGeneralController : ApiController
    {
        [HttpGet]
        public IEnumerable<TGeneral_EL> GET()
        {
            return TGeneral_DA.Accion.Sel_ComboTGeneral();
        }

        [HttpPost]
        [Route("Lista")]
        public IEnumerable<TGeneral_EL> Lista(TGeneral_EL val)
        {
            return TGeneral_DA.Accion.GetAllTGeneral(val);
        }

        [HttpPost]
        public int POST(TGeneral_EL value)
        {
            return TGeneral_DA.Accion.InsertTGeneral(value);
        }

        [HttpPut]
        public int Put(int id, TGeneral_EL value)
        {
            return TGeneral_DA.Accion.UpdateTGeneral(value);
        }

        [HttpPost]
        [Route("Delete")]
        public int Delete(TGeneral_EL val)
        {
            return TGeneral_DA.Accion.DeleteTGeneral(val);
        }
    }
}
