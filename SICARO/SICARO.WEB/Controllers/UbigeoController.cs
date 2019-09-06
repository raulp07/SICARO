using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SICARO.WEB.Controllers
{
    public class UbigeoController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Ubigeo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CargaComboUbigeo(UBIGEO_EL Datos)
        {
            try
            {
                string postdata = js.Serialize(Datos);
                List<UBIGEO_EL> Lista = new List<UBIGEO_EL>();
                Lista = js.Deserialize<List<UBIGEO_EL>>(Utilitario.Accion.ConectREST("UBIGEO", "POST", postdata));
                return Json(new { Lista = Lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}