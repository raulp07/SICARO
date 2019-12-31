using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SICARO.WEB.Controllers
{
    public class CapacitacionController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Capacitacion
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult ListaCapacitacion()
        {
            try
            {

                var Lis = JsonConvert.DeserializeObject<List<CAPACITACION_EL>>(Utilitario.Accion.Conect_WEBAPI("CAPACITACION", "GET"));
                return Json(new { ListaCAPACITACION = Lis }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaCAPACITACION = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListaPersonal(string val)
        {
            var ListaPersonal = JsonConvert.DeserializeObject<List<PERSONAL_EL>>(Utilitario.Accion.Conect_WEBAPI("PERSONAL", "GET", "", val));
            return Json(new { ListaPersonal = ListaPersonal, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult RegistrarCapacitacionCabecera(CAPACITACION_EL GestionCapacitacion)
        {
            string perosnalizaicon = "1";
            string postdata = JsonConvert.SerializeObject(GestionCapacitacion);
            int respuesta = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("CAPACITACION", "POST", postdata));

            return Json(new { perosnalizaicon = perosnalizaicon, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ActualizarCapacitacionCabecera(CAPACITACION_EL GestionCapacitacion)
        {
            string perosnalizaicon = "1";
            string postdata = JsonConvert.SerializeObject(GestionCapacitacion);
            int respuesta = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("CAPACITACION", "PUT", postdata, GestionCapacitacion.iIdCapacitacion.ToString()));

            return Json(new { perosnalizaicon = perosnalizaicon, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult RegistrarCapacitacion(GESTION_CAPACITACION_EL GestionCapacitacion, List<PREGUNTA_EL> _Preguntas, List<CAPACITACION_PERSONAL_EL> _CapacitacionPersonal)
        {
            string perosnalizaicon = "1";
            var xmlPreguntas = Utilitario.Serialize(_Preguntas).Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Replace("<? xml version = \"1.0\" encoding = \"UTF-8\" ?>", "");
            var xmlCapacitacionPersonal = Utilitario.Serialize(_CapacitacionPersonal).Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Replace("<? xml version = \"1.0\" encoding = \"UTF-8\" ?>", "");
            GestionCapacitacion.XMLPreguntas = xmlPreguntas;
            GestionCapacitacion.XMLCapacitacionPersonal = xmlCapacitacionPersonal;
            string postdata = JsonConvert.SerializeObject(GestionCapacitacion);
            int respuesta = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("GESTION_CAPACITACION", "POST", postdata));

            return Json(new { perosnalizaicon = perosnalizaicon, JsonRequestBehavior.AllowGet });
        }

        

        [HttpPost]
        public JsonResult ListarGestionCapacitacion(string value)
        {
            //List<PREGUNTA_EL> preguntas = new List<PREGUNTA_EL>();
            //List<OPCION_PREGUNTA_EL> Opciones = new List<OPCION_PREGUNTA_EL>();
            var Capacitacion = JsonConvert.DeserializeObject<IEnumerable<GESTION_CAPACITACION_EL>>(Utilitario.Accion.Conect_WEBAPI("GESTION_CAPACITACION", "GET", "", value));

            var preguntas = JsonConvert.DeserializeObject<List<PREGUNTA_EL>>(Utilitario.Accion.Conect_WEBAPI("PREGUNTA/TESTPREGUNTA", "GET", "", value));

            var Opciones = JsonConvert.DeserializeObject<List<OPCION_PREGUNTA_EL>>(Utilitario.Accion.Conect_WEBAPI("OPCION_PREGUNTA/TESTPREGUNTAOPCION", "GET", "", value));

            var Capacitacion_Personal = JsonConvert.DeserializeObject<List<CAPACITACION_PERSONAL_EL>>(Utilitario.Accion.Conect_WEBAPI("CAPACITACION_PERSONAL/GETCAPACITACION_PERSONAL", "GET", "", "0&value2=0&value3=" + value));

            return Json(new { Capacitacion = Capacitacion, preguntas = preguntas, Opciones = Opciones, Capacitacion_Personal = Capacitacion_Personal }, JsonRequestBehavior.AllowGet);
        }

        // GET: Capacitacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Capacitacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Capacitacion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Capacitacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Capacitacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Capacitacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Capacitacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
