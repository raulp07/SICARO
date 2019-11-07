using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SICARO.WEB.Controllers
{
    public class ProveedorController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ListarProveedor(PROVEEDOR_EL MP)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(MP);
                var data = JsonConvert.DeserializeObject<List<PROVEEDOR_EL>>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "GET", "", MP.iIdProveedor.ToString()));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Ins_PROVEEDOR(PROVEEDOR_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "POST", postdata));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult Upd_PROVEEDOR(PROVEEDOR_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "PUT", postdata, "0"));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult Del_PROVEEDOR(PROVEEDOR_EL Datos)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(Datos);
                var data = JsonConvert.DeserializeObject<int>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "DEL", "", Datos.iIdProveedor.ToString()));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }


        //[HttpPost]
        //public JsonResult ListarProveedor(PROVEEDOR_EL MP)
        //{
        //    try
        //    {
        //        string postdata = js.Serialize(MP);
        //        List<PROVEEDOR_EL> data = new List<PROVEEDOR_EL>();
        //        data = js.Deserialize<List<PROVEEDOR_EL>>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "GET", postdata));
        //        return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}