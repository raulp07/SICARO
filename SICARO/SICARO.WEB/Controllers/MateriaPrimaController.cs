using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICARO.WEB.Controllers
{
    public class MateriaPrimaController : Controller
    {
        // GET: MateriaPrima
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ListarMateriaPrima(MATERIA_PRIMA_EL MP)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(MP);
                var data = JsonConvert.DeserializeObject<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.Conect_WEBAPI("MATERIA_PRIMA", "GET", "", MP.iIdMateriaPrima));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Ins_MATERIA_PRIMA(MATERIA_PRIMA_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("MATERIA_PRIMA", "POST", postdata));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult Upd_MATERIA_PRIMA(MATERIA_PRIMA_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("MATERIA_PRIMA", "PUT", postdata, 0));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult Del_MATERIA_PRIMA(MATERIA_PRIMA_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("MATERIA_PRIMA", "DEL", "", Datos.iIdMateriaPrima));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }
    }
}