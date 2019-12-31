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
    [RoutePrefix("api/PRODUCTO_MATERIAPRIMA")]
    public class PRODUCTO_MATERIAPRIMAController : ApiController
    {
        [HttpGet]
        public IEnumerable<PRODUCTO_MATERIAPRIMA_EL> GET(int value)
        {
            return PRODUCTO_MATERIAPRIMA_DA.Accion.GetAllProveedor_Producto(value);
        }

        //[HttpPost]
        //public int POST(PRODUCTO_MATERIAPRIMA_EL value)
        //{
        //    return PRODUCTO_MATERIAPRIMA_DA.Accion.InsertPRODUCTO_MATERIAPRIMA(value);
        //}

        //[HttpPut]
        //public int Put(int id, PRODUCTO_MATERIAPRIMA_EL value)
        //{
        //    return PRODUCTO_MATERIAPRIMA_DA.Accion.UpdatePRODUCTO_MATERIAPRIMA(value);
        //}


    }
}
