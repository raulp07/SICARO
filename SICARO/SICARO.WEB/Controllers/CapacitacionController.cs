using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        public JsonResult ListaPersonal(int val)
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
            int respuesta = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("CAPACITACION", "PUT", postdata, GestionCapacitacion.iIdCapacitacion));

            return Json(new { perosnalizaicon = perosnalizaicon, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult RegistrarCapacitacion(GESTION_CAPACITACION_EL GestionCapacitacion, List<PREGUNTA_EL> _Preguntas, List<OPCION_PREGUNTA_EL> _Respuestas)
        {
            string perosnalizaicon = "1";
            string postdata = JsonConvert.SerializeObject(GestionCapacitacion);
            int respuesta = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("GESTION_CAPACITACION", "POST", postdata));

            foreach (PREGUNTA_EL item in _Preguntas)
            {
                string postdataP = JsonConvert.SerializeObject(item);
                int respuestaP = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("PREGUNTA", "POST", postdataP));
                foreach (OPCION_PREGUNTA_EL itemR in _Respuestas)
                {
                    if (item.iIdPregunta == itemR.iIdPregunta)
                    {
                        string postdataR = JsonConvert.SerializeObject(itemR);
                        int respuestaR = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("OPCION_PREGUNTA", "POST", postdataR));
                    }
                }
            }

            return Json(new { perosnalizaicon = perosnalizaicon, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ListarGestionCapacitacion(int value)
        {
            var respuesta = JsonConvert.DeserializeObject<IEnumerable<GESTION_CAPACITACION_EL>>(Utilitario.Accion.Conect_WEBAPI("GESTION_CAPACITACION", "GET", "", value));
            return Json(respuesta, JsonRequestBehavior.AllowGet);
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
