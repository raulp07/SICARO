using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SICARO.WEB.Controllers
{
    public class PrediccionesController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Predicciones
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
                return Json(new { ListaProducto = ListaProducto }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaProducto = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListaMateriaPrima(MATERIA_PRIMA_EL MP)
        {
            try
            {
                var ListaMATERIA_PRIMA = js.Deserialize<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.Conect_WEBAPI("MATERIA_PRIMA", "GET", "", "0"));
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
                var ListaMATERIA_PRIMAProveedor = js.Deserialize<List<PROVEEDOR_MATERIAPRIMA_EL>>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR_MATERIAPRIMA", "GET", "", "0&value2=" + MP.iIdMateriaPrima));

                return Json(new { ListaMATERIA_PRIMAProveedor = ListaMATERIA_PRIMAProveedor }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMAProveedor = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GuardarPronosticos(CONTROLPRODUCCION_EL P)
        {
            try
            {
                

                //string envios = "raulpaucar7@gmail.com";
                //MailMessage correo = new MailMessage();
                //correo.From = new MailAddress("Sys.ICARO@gmail.com");

                //var listaCorreos = envios.Split(';');
                //foreach (string item in listaCorreos)
                //{
                //    correo.To.Add(item);
                //}

                //correo.Subject = "Prueba";
                //correo.Body = "empieza la prueba";
                //correo.IsBodyHtml = true;
                //correo.Priority = MailPriority.Normal;

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 25;
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = true;
                //string cuentacorreo = "Sys.ICARO@gmail.com";
                //string password = "webicar0";
                //smtp.Credentials = new System.Net.NetworkCredential(cuentacorreo,password);

                //smtp.Send(correo);


                var ListaPrediccionGrafica = new object();
                string data = "";
                string consulta = "";
                string Llamada = "";
                switch (P.tipoPronostico)
                {
                    case 1:
                        data = P.idProducto + "&value2=" + P.idProveedor + "&value3=" + P.idUnidadMedida + "&value4=" + P.idIntervaloProduccion;
                        consulta = "producto=" + P.idProducto + "&proveedor=" + P.idProveedor + "&unidadmedida=" + P.idUnidadMedida + "&peso=" + P.Peso + "&vecesutilizadoprod=" + P.idIntervaloProduccion;
                        Llamada = "duracioninsumo";
                        ListaPrediccionGrafica = js.Deserialize<List<pronostico_duracion_insumo_EL>>(Utilitario.Accion.Conect_WEBAPI("PREDICCION/pronostico_duracion_insumo", "GET", "", data));
                        break;
                    case 2:
                        data = P.idProducto + "&value2=" + P.idProveedor + "&value3=" + P.idUnidadMedida;
                        consulta = "producto=" + P.idProducto + "&proveedor=" + P.idProveedor + "&unidadmedida=" + P.idUnidadMedida + "&peso=" + P.Peso;
                        Llamada = "arriboinsumo";
                        ListaPrediccionGrafica = js.Deserialize<List<pronostico_arribo_insumo_EL>>(Utilitario.Accion.Conect_WEBAPI("PREDICCION/pronostico_arribo_insumo", "GET", "", data));
                        break;
                    case 3:
                        data = P.idProducto + "&value2=" + P.idActividad;
                        consulta = "producto=" + P.idProducto + "&actividad=" + P.idActividad + "&cantidad=" + P.cantidadProducida;
                        Llamada = "cantidadproducida";
                        ListaPrediccionGrafica = js.Deserialize<List<pronostico_cantidad_producida_EL>>(Utilitario.Accion.Conect_WEBAPI("PREDICCION/pronostico_cantidad_producida", "GET", "", data));
                        break;
                    case 4:
                        data = P.idProducto + "&value2=" + P.idProveedor + "&value3=" + P.idUnidadMedida;
                        consulta = "producto=" + P.idProducto + "&proveedor=" + P.idProveedor + "&unidadmedida=" + P.idUnidadMedida + "&peso=" + P.Peso;
                        Llamada = "mermainsumo";
                        ListaPrediccionGrafica = js.Deserialize<List<pronostico_merma_insumo_EL>>(Utilitario.Accion.Conect_WEBAPI("PREDICCION/pronostico_merma_insumo", "GET", "", data));
                        break;
                    default:
                        break;
                }
                
                var resultado = new Respuesta();
                //respuesta.prediccion = "12.23213";
                //respuesta.exactitud = "0.236543";
                //respuesta.mse = "16.21";

                resultado = js.Deserialize<Respuesta>(Utilitario.Accion.Conect_WEBPython(Llamada, "GET", "", consulta));
                if (resultado == null)
                {
                    resultado = new Respuesta();
                    resultado.prediccion = "0";
                    resultado.exactitud = "0";
                    resultado.mse = "0";
                }
                else{
                    resultado.mse = Math.Round(Convert.ToDecimal(resultado.mse), 2).ToString();
                }


                P.PRECISION = Convert.ToInt16(decimal.Round(Convert.ToDecimal(resultado.exactitud) * 100)) + "%";
                P.ErrorMedioCuadratico = Math.Round(Convert.ToDecimal(resultado.mse), 2).ToString();
                P.predicion = Convert.ToInt16(decimal.Round(Convert.ToDecimal(resultado.prediccion)));

                 

                string postdata = JsonConvert.SerializeObject(P);
                var Res = js.Deserialize<int>(Utilitario.Accion.Conect_WEBAPI("CONTROLPRODUCCION", "POST", postdata));


                return Json(new { resultado = resultado, ListaPrediccionGrafica = ListaPrediccionGrafica }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { resultado = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        public class Respuesta
        {
            public string prediccion { get; set; }
            public string exactitud { get; set; }
            public string mse { get; set; }

        }
    }
}