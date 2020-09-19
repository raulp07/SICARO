using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Net;

namespace SICARO.WEB.Controllers
{
    public class PronosticoController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Pronostico

        [ActionName("Index2")]
        public ActionResult Index2()
        {
            
            ViewBag.Tipopronostico = 1;
            //ViewBag.Producto = 201;
            //ViewBag.Proveedor = 1;
            //ViewBag.Intervalo = 1;
            //ViewBag.Actividad = 0;
            //ViewBag.Prediccion = 6;
            return View();
        }

        [ActionName("Index")]
        public ActionResult Index(int tipopronostico,int producto, int proveedor, int intervalo, int actividad,int Prediccion)
        {
            ViewBag.Tipopronostico = tipopronostico;
            ViewBag.Producto = producto;
            ViewBag.Proveedor = proveedor;
            ViewBag.Intervalo = intervalo;
            ViewBag.Actividad = actividad;
            ViewBag.Prediccion = Prediccion;
            return View();
        }

        [HttpPost]
        public JsonResult ListaProducto()
        {
            try
            {
                var ListaProducto = js.Deserialize<List<PRODUCTO_EL>>(Utilitario.Accion.Conect_WEBAPI("PRODUCTO", "GET", "", "0"));
                //var Listado = JsonConvert.DeserializeObject<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.ConectREST("MATERIA_PRIMA", "POST", postdata));
                return Json(new { ListaProducto = ListaProducto }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListaMateriaPrima(MATERIA_PRIMA_EL MP)
        {
            try
            {
                var ListaMATERIA_PRIMA = js.Deserialize<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.Conect_WEBAPI("MATERIA_PRIMA", "GET", "", "0"));
                //var Listado = JsonConvert.DeserializeObject<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.ConectREST("MATERIA_PRIMA", "POST", postdata));
                return Json(new { ListaMATERIA_PRIMA = ListaMATERIA_PRIMA }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMA = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListaMateriaPrimaProveedor(MATERIA_PRIMA_EL MP)
        {
            try
            {
                var ListaMATERIA_PRIMAProveedor = js.Deserialize<List<PROVEEDOR_MATERIAPRIMA_EL>>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "GET", "", "0&value2=" + MP.iIdMateriaPrima));
                return Json(new { ListaMATERIA_PRIMAProveedor = ListaMATERIA_PRIMAProveedor }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMAProveedor = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListaControlProduccion(CONTROLPRODUCCION_EL MP)
        {
            try
            {
                string parametros = "";
                parametros = "0&value2=" + MP.tipoPronostico;
                parametros += "&value3=" + MP.idProducto;
                parametros += "&value4=" + MP.idProveedor;
                parametros += "&value5=" + MP.idIntervaloProduccion;
                parametros += "&value6=" + MP.idActividad;
                var CONTROLPRODUCCION = js.Deserialize<List<CONTROLPRODUCCION_EL>>(Utilitario.Accion.Conect_WEBAPI("CONTROLPRODUCCION", "GET", "", parametros));
                return Json(new { CONTROLPRODUCCION = CONTROLPRODUCCION }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { CONTROLPRODUCCION = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GuardarControlProduccion(string CorreoContenido)
        {
            try
            {
                
                int resultado = js.Deserialize<int>(Utilitario.Accion.Conect_WEBAPI("CONTROLPRODUCCION/ActualizarColor", "GET"));

                if (CorreoContenido != "")
                {
                    var res = Utilitario.Accion.EnvioCorreo("presidente.calidad.wislan@gmail.com",
                    "Indicadores Predicciones ",
                    CorreoContenido);
                }
                
                return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { resultado = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GuardarCategoriaRango(CATEGORIA_EL C)
        {
            try
            {
                string postdata = JsonConvert.SerializeObject(C);
                var Res = js.Deserialize<int>(Utilitario.Accion.Conect_WEBAPI("CATEGORIA/CategoriaRango", "POST", postdata));
                return Json(Res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { resultado = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        private void EnviarCorreo()
        {

            //SmtpClient SmtpServer = new SmtpClient();
            //MailMessage mail = new MailMessage();
            //SmtpServer.Credentials = new NetworkCredential("raul.paucar.iq@quasys.com.pe", "R@u70101");
            //SmtpServer.Port = 25;
            //SmtpServer.Host = "Smtp.gmail.com";
            //mail = new MailMessage();
            //mail.From = new MailAddress("raul.paucar.iq@quasys.com.pe", "DISPLAY NAME");
            //mail.To.Add("raul.paucar.iq@quasys.com.pe");
            //mail.Subject = "YOUR SUBJECT";
            //mail.Body = "YOUR MESSAGE";
            //SmtpServer.Send(mail);

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("raulpaucar7@gmail.com");
            correo.To.Add("raulpaucar7@gmail.com");
            correo.Subject = "prueba";
            correo.Body = "data";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = true;
            string sCuentaCorreo = "raulpaucar7@gmail.com";
            string sPasswordCorreo = "";
            smtp.Credentials = new NetworkCredential(sCuentaCorreo, sPasswordCorreo);

            try
            {
                smtp.Send(correo);

            }
            catch (Exception ex)
            {

                throw;
            }


        }


    }
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string MailBody { get; set; }
    }
}