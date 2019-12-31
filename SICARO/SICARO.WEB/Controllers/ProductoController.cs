using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICARO.WEB.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarProducto(PRODUCTO_EL DA)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<List<PRODUCTO_EL>>(Utilitario.Accion.Conect_WEBAPI("PRODUCTO", "GET", "", DA.iIdproducto.ToString()));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListarProductoProveedor(PRODUCTO_EL DA)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<List<PRODUCTO_MATERIAPRIMA_EL>>(Utilitario.Accion.Conect_WEBAPI("PRODUCTO_MATERIAPRIMA", "GET", "", DA.iIdproducto.ToString()));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}