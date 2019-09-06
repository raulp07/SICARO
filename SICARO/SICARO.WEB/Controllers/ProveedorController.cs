﻿using SICARO.WEB.Models;
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
                string postdata = js.Serialize(MP);
                List<PROVEEDOR_EL> data = new List<PROVEEDOR_EL>();
                data = js.Deserialize<List<PROVEEDOR_EL>>(Utilitario.Accion.ConectREST("PROVEEDOR", "POST", postdata));
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}