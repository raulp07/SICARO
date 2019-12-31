using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICARO.WEB.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListarRol(Rol_EL Datos)
        {
            try
            {
                var lista = JsonConvert.DeserializeObject<List<Rol_EL>>(Utilitario.Accion.Conect_WEBAPI("Rol", "GET","", Datos.Id.ToString()));
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult InsertRol(Rol_EL Datos)
        {
            try
            {
                string data = JsonConvert.SerializeObject(Datos);
                var lista = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("Rol", "POST", data));
                return Json(new { Data = lista, Error = "0" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult InsertOpcionRol(List<PerfilEL> op, int idRol) {
            try
            {
                var xmlOpcionRol = Utilitario.Serialize(op).Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Replace("<? xml version = \"1.0\" encoding = \"UTF-8\" ?>", "");
                Opcion_EL pel = new Opcion_EL(){
                    Id=idRol,
                    Nombre = xmlOpcionRol
                };
                string data = JsonConvert.SerializeObject(pel);
                
                var lista = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("OpcionXPerfil", "POST", data));
                return Json(new { Data = lista, Error = "0" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}