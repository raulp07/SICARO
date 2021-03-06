﻿using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SICARO.WEB.Controllers
{
    public class TestEvaluacionController : Controller
    {

        // GET: TestEvaluacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public JsonResult GenerarCamposCapacitacion()
        {

            var ListaPregunta = JsonConvert.DeserializeObject<List<PREGUNTA_EL>>(Utilitario.Accion.Conect_WEBAPI("PREGUNTA", "GET", "", "0&value2=" + SesionUsuario.Usuario.Id));

            var ListaOpciones = JsonConvert.DeserializeObject<List<OPCION_PREGUNTA_EL>>(Utilitario.Accion.Conect_WEBAPI("OPCION_PREGUNTA", "GET", "", "0"));
            return Json(new { ListaPregunta = ListaPregunta, ListaOpciones = ListaOpciones }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult RegistrarTest(CAPACITACION_PERSONAL_EL parametros, List<DETALLE_CAPACITACION_PERSONAL_EL> Detalle_Capacitacion)
        {
            parametros.iIdPersonal = SesionUsuario.Usuario.Id;
            string postdata = JsonConvert.SerializeObject(parametros);

            foreach (DETALLE_CAPACITACION_PERSONAL_EL item in Detalle_Capacitacion)
            {
                item.iIdDetalleCapacitacionPersonal = 1;
                item.iIdCapacitacionPersonal = SesionUsuario.Usuario.Id;
            }

            string postdataDetalleCapacitacion = JsonConvert.SerializeObject(Detalle_Capacitacion);

            int respuesta = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("CAPACITACION_PERSONAL", "POST", postdata));

            int respuestaP = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("DETALLE_CAPACITACION_PERSONAL", "POST", postdataDetalleCapacitacion));
            

            return Json(new { respuesta = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}