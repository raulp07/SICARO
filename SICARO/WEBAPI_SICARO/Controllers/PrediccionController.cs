using System.Collections.Generic;
using System.Web.Http;
using WEBAPI_SICARO.Models;
using WEBAPI_SICARO.Persistencia;

namespace WEBAPI_SICARO.Controllers
{
    [RoutePrefix("api/PREDICCION")]
    public class PrediccionController : ApiController
    {
        [HttpGet]
        [Route("pronostico_duracion_insumo")]
        public IEnumerable<pronostico_duracion_insumo_EL> pronostico_duracion_insumo(int value,int value2,int value3, int value4)
        {
            return Prediccion_DA.Accion.GetAllpronostico_duracion_insumo(value, value2,value3,value4);
        }

        [HttpGet]
        [Route("pronostico_arribo_insumo")]
        public IEnumerable<pronostico_arribo_insumo_EL> pronostico_arribo_insumo(int value, int value2, int value3)
        {
            return Prediccion_DA.Accion.GetAllpronostico_arribo_insumo(value, value2, value3);
        }

        [HttpGet]
        [Route("pronostico_cantidad_producida")]
        public IEnumerable<pronostico_cantidad_producida_EL> pronostico_cantidad_producida(int value, int value2)
        {
            return Prediccion_DA.Accion.GetAllpronostico_cantidad_producida(value, value2);
        }

        [HttpGet]
        [Route("pronostico_merma_insumo")]
        public IEnumerable<pronostico_merma_insumo_EL> pronostico_merma_insumo(int value, int value2, int value3)
        {
            return Prediccion_DA.Accion.GetAllpronostico_merma_insumo(value, value2, value3);
        }
    }
}