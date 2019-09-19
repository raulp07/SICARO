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
    public class PERSONALController : ApiController
    {
        public IEnumerable<PERSONAL_EL> GET(PERSONAL_EL value)
        {
            return PERSONAL_DA.Accion.GetAllPERSONAL(value);
        }

        public int POST(PERSONAL_EL value)
        {
            return PERSONAL_DA.Accion.InsertPERSONAL(value);
        }

        // PUT api/values/5
        public int Put(int id,PERSONAL_EL value)
        {
            return PERSONAL_DA.Accion.UpdatePERSONAL(value);
        }
    }
}
