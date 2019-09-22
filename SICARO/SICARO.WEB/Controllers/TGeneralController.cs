using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICARO.WEB.Controllers
{
    public class TGeneralController : Controller
    {
        // GET: TGeneral
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CargaTGeneral(TGeneral_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<List<TGeneral_EL>>(Utilitario.Accion.Conect_WEBAPI("TGeneral/Lista", "POST", postdata));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Sel_TGeneral(TGeneral_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<List<TGeneral_EL>>(Utilitario.Accion.Conect_WEBAPI("TGeneral/Lista", "POST", postdata));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Sel_ComboTGeneral()
        {
            try
            {
                var data = JsonConvert.DeserializeObject<List<TGeneral_EL>>(Utilitario.Accion.Conect_WEBAPI("TGeneral", "GET"));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult Ins_TGeneral(TGeneral_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("TGeneral", "POST", postdata));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult Upd_TGeneral(TGeneral_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("TGeneral", "PUT", postdata, 0));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult Del_TGeneral(TGeneral_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("TGeneral/Delete", "POST", postdata, 0));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }


    }
}