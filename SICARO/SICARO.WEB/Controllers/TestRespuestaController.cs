using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SICARO.WEB.Controllers
{
    public class TestRespuestaController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: TestRespuesta
        public ActionResult Index()
        {
            ViewBag.Capacitacion = Request.QueryString["value"] == null ? "0" : Request.QueryString["value"];
            return View();
        }

        [HttpPost]
        public JsonResult VisualizarTest(string idCapacitacion)
        {
            var ListaPregunta = js.Deserialize<List<PREGUNTA_EL>>(Utilitario.Accion.Conect_WEBAPI("PREGUNTA/TESTPREGUNTA", "GET", "", idCapacitacion));
            var ListaOpciones = js.Deserialize<List<OPCION_PREGUNTA_EL>>(Utilitario.Accion.Conect_WEBAPI("opcion_pregunta/TESTPREGUNTAOPCION", "GET", "", idCapacitacion));

            return Json(new { ListaPregunta = ListaPregunta, ListaOpciones = ListaOpciones }, JsonRequestBehavior.AllowGet);
        }

    }
}