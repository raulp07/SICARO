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
    public class UBIGEOController : ApiController
    {
        public IEnumerable<UBIGEO_EL> GET(UBIGEO_EL value)
        {
            return UBIGEO_DA.Accion.GetAllUBIGEO(value);
        }
    }
}
