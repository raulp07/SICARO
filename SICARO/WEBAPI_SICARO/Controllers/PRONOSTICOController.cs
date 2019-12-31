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
        public ActionResult Index()
        {
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
                var resultado = "";// js.Deserialize<object>(Utilitario.Accion.Conect_WEBPython("escenario1", "GET", "", "producto=1&proveedor=1&unidadmedida=1&peso=15"));
                var CONTROLPRODUCCION = js.Deserialize<List<CONTROLPRODUCCION_EL>>(Utilitario.Accion.Conect_WEBAPI("CONTROLPRODUCCION", "GET", "","0&value2="+ MP.idProducto));
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
                //EnviarCorreo();
                string postdata = js.Serialize(P);
                int resultado = js.Deserialize<int>(Utilitario.Accion.Conect_WEBAPI("CONTROLPRODUCCION", "POST", postdata));
                return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
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
            string sPasswordCorreo = "S3fir0th..";
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