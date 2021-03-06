﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_SICARO.Modles;
using WEBAPI_SICARO.Persistencia;
namespace WEBAPI_SICARO.Controllers
{
    [RoutePrefix("api/PREGUNTA")]
    public class PREGUNTAController : ApiController
    {
        [HttpGet]
        public IEnumerable<PREGUNTA_EL> GET(int value,int? value2)
        {
            return PREGUNTA_DA.Accion.GetAllPREGUNTA(value, value2);
        }

        [HttpPost]
        public int POST(PREGUNTA_EL value)
        {
            return PREGUNTA_DA.Accion.InsertPREGUNTA(value);
        }

        [HttpPut]
        public int Put(int id,PREGUNTA_EL value)
        {
            return PREGUNTA_DA.Accion.UpdatePREGUNTA(value);
        }

        [HttpGet]
        [Route("TESTPREGUNTA")]
        public IEnumerable<PREGUNTA_EL> TESTPREGUNTA(int value,int value2 = 0)
        {
            return PREGUNTA_DA.Accion.GetTestPREGUNTA(value, value2);
        }

    }
}
