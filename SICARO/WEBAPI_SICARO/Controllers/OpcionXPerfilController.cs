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
    public class OpcionXPerfilController : ApiController
    {
        public IEnumerable<OpcionXPerfil_EL> GET(OpcionXPerfil_EL value)
        {
            return OpcionXPerfil_DA.Accion.ListMenu(value);
        }

        //public int POST(OpcionXPerfil_EL value)
        //{
        //    return OpcionXPerfil_DA.Accion.InsertOpcionXPerfil(value);
        //}

        //// PUT api/values/5
        //public int Put(int id,OpcionXPerfil_EL value)
        //{
        //    return OpcionXPerfil_DA.Accion.UpdateOpcionXPerfil(value);
        //}
    }
}
