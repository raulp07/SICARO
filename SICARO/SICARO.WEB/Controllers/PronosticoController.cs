﻿using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SICARO.WEB.Controllers
{
    public class PronosticoController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Pronostico
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListaMateriaPrima(MATERIA_PRIMA_EL MP)
        {
            try
            {
                string postdata = js.Serialize(MP);
                List<MATERIA_PRIMA_EL> ListaMATERIA_PRIMA = new List<MATERIA_PRIMA_EL>();
                ListaMATERIA_PRIMA = js.Deserialize<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.ConectREST("MATERIA_PRIMA", "POST", postdata));
                //var Listado = JsonConvert.DeserializeObject<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.ConectREST("MATERIA_PRIMA", "POST", postdata));
                return Json(new { ListaMATERIA_PRIMA = ListaMATERIA_PRIMA }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListaMateriaPrimaProveedor(PROVEEDOR_EL MP)
        {
            try
            {
                string postdata = js.Serialize(MP);
                List<PROVEEDOR_EL> ListaMATERIA_PRIMAProveedor = new List<PROVEEDOR_EL>();
                ListaMATERIA_PRIMAProveedor = js.Deserialize<List<PROVEEDOR_EL>>(Utilitario.Accion.ConectREST("PROVEEDOR", "POST", postdata));
                return Json(new { ListaMATERIA_PRIMAProveedor = ListaMATERIA_PRIMAProveedor }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMAProveedor = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListaControlProduccion(PROVEEDOR_EL MP)
        {
            try
            {
                string postdata = js.Serialize(MP);
                List<CONTROLPRODUCCION_EL> CONTROLPRODUCCION = new List<CONTROLPRODUCCION_EL>();
                CONTROLPRODUCCION = js.Deserialize<List<CONTROLPRODUCCION_EL>>(Utilitario.Accion.ConectREST("CONTROLPRODUCCION", "POST", postdata));
                return Json(new { CONTROLPRODUCCION = CONTROLPRODUCCION }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { CONTROLPRODUCCION = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GuardarControlProduccion(CONTROLPRODUCCION_EL P)
        {
            try
            {
                string postdata = js.Serialize(P);
                int resultado = js.Deserialize<int>(Utilitario.Accion.ConectREST("ICONTROLPRODUCCION", "POST", postdata));
                return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { resultado = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        

    }
}