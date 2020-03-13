using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICARO.WEB.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListarPersonal()
        {
            try
            {
                var Data = JsonConvert.DeserializeObject<List<PERSONAL_EL>>(Utilitario.Accion.Conect_WEBAPI("Personal", "GET", "", "0"));
                return Json(new { Data = Data, Error = "0" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Ins_PERSONAL(PERSONAL_EL personal)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(personal);
                var Data = JsonConvert.DeserializeObject<Respuesta>(Utilitario.Accion.Conect_WEBAPI("Personal", "POST", postdata));
                return Json(Data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Upd_PERSONAL(PERSONAL_EL personal)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(personal);
                var Data = JsonConvert.DeserializeObject<Respuesta>(Utilitario.Accion.Conect_WEBAPI("Personal", "PUT", postdata));
                return Json(Data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Del_PERSONAL(PERSONAL_EL personal)
        {
            var Data = JsonConvert.DeserializeObject<Respuesta>(Utilitario.Accion.Conect_WEBAPI("Personal", "DEL", "", personal.iIdPersonal.ToString()));
            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GestionarUsusario(USUARIO_EL usu)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(usu);
                var Data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("USUARIO/GestionarUsuario", "POST", postdata));
                return Json(new { Data = Data, Error = "0" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}