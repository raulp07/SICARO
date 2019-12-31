using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICARO.WEB.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ListarMenu(int idOpcion)
        {
            try
            {
                var Data = JsonConvert.DeserializeObject<List<Opcion_EL>>(Utilitario.Accion.Conect_WEBAPI("OPCION/GETOPCION", "GET", "", idOpcion.ToString()));
                return Json(new { Data = Data, Error = "0" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult OpcionXPerfil(string idOpcion,string rol)
        {
            try
            {
                var DataOpcion = JsonConvert.DeserializeObject<List<Opcion_EL>>(Utilitario.Accion.Conect_WEBAPI("OPCION/GETOPCION", "GET", "", idOpcion));
                var DataOpcionPerfil = JsonConvert.DeserializeObject<List<OpcionXPerfil_EL>>(Utilitario.Accion.Conect_WEBAPI("OpcionXPerfil", "GET", "", rol));
                return Json(new { DataOpcion = DataOpcion, DataOpcionPerfil = DataOpcionPerfil, Error = "0" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult InsertMenu(Opcion_EL idOpcion)
        {
            try
            {
                string datapost = JsonConvert.SerializeObject(idOpcion);
                var Data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("OPCION", "POST", datapost));
                return Json(new { Data = Data, Error = "0" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Mensaje = e.Message, Error = "1" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}