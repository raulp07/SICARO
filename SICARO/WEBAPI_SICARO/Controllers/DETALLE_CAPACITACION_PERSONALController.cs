using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI_SICARO.Models;
using WEBAPI_SICARO.Modles;
using WEBAPI_SICARO.Persistencia;


namespace WEBAPI_SICARO.Controllers
{
    [RoutePrefix("api/DETALLE_CAPACITACION_PERSONAL")]
    public class DETALLE_CAPACITACION_PERSONALController : ApiController
    {
        [HttpGet]
        public IEnumerable<DETALLE_CAPACITACION_PERSONAL_EL> GET(int value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.GetAllDETALLECAPACITACIONPERSONAL(value);
        }

        [HttpPost]
        public int POST(IEnumerable<DETALLE_CAPACITACION_PERSONAL_EL> value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.InsertDETALLE_CAPACITACION_PERSONAL(value);
        }

        [HttpPut]
        public int Put(int id, DETALLE_CAPACITACION_PERSONAL_EL value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.UpdateDETALLE_CAPACITACION_PERSONAL(value);
        }

        [HttpGet]
        [Route("GetAllDETALLECAPACITACIONPERSONALSERVICIO")]
        public List<ElementosSaliente> GetAllDETALLECAPACITACIONPERSONALSERVICIO(int value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.GetAllDETALLECAPACITACIONPERSONALSERVICIO(value);
        }

        [HttpGet]
        [Route("GetPREGUNTAS_CORRECTAS")]
        public List<PREGUNTAS_CORRECTAS> GetPREGUNTAS_CORRECTAS(int value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.GetPREGUNTAS_CORRECTAS(value);
        }
        

        [HttpGet]
        [Route("graficoAlumnosAprobados")]
        public ReporteGrafico_EL graficoAlumnosAprobados(int value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.graficoAlumnosAprobados(value);
        }

        [HttpGet]
        [Route("preguntaMayorMenorAcierto")]
        public IEnumerable<ReporteGrafico_EL> preguntaMayorMenorAcierto(int value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.preguntaMayorMenorAcierto(value);
        }

        [HttpGet]
        [Route("NumeroAciertosPorPregunta")]
        public IEnumerable<ReporteGrafico_EL> NumeroAciertosPorPregunta(int value)
        {
            return DETALLE_CAPACITACION_PERSONAL_DA.Accion.NumeroAciertosPorPregunta(value);
        }
    }
}
