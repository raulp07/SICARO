using Newtonsoft.Json;

using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Rotativa;

namespace SICARO.WEB.Controllers
{
    public class ReporteController : Controller
    {
        static string ReporteGenerador = "";
        static string NombreReporte = "REPORTEINSPECCIONSANITARIA";
        static string Extencion = ".PDF";
        static string ArchivoReporte = NombreReporte + Extencion;
        static string RutaPDF = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Documentos\PDF\");
        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Reporte
        public ActionResult Index()
        {
            foreach (var item in Directory.GetFiles(RutaPDF, "*.PDF"))
            {
                try
                {

                    System.IO.File.SetAttributes(item, FileAttributes.Normal);
                    System.IO.File.Delete(item);
                }
                catch (Exception)
                {
                }
            }
            return View();
        }


        public ActionResult PDF()
        {
            ViewBag.html = ReporteGenerador;
            return View();
        }

        public ActionResult ImprimirPDF()
        {
            var actionResult = new ActionAsPdf("PDF")
            { FileName = "test.pdf" };
            var misDatos = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RutaPDF + ArchivoReporte);
            var byteArray = actionResult.BuildPdf(ControllerContext);
            try
            {
                using (var fileStream = new FileStream(misDatos, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fileStream.Write(byteArray, 0, byteArray.Length);
                    fileStream.Close();
                }

            }
            catch (Exception)
            {
                ArchivoReporte = NombreReporte + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + Extencion;
                misDatos = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RutaPDF + ArchivoReporte);
                using (var fileStream = new FileStream(misDatos, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fileStream.Write(byteArray, 0, byteArray.Length);
                    fileStream.Close();
                }

            }


            return actionResult;
        }

        [HttpPost]
        public JsonResult GuardarEstructuraReporte(string datos)
        {
            ReporteGenerador = datos;
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EnviarCorreo(string Detinatario, string Asunto)
        {
            //System.IO.File.Copy(RutaPDF + ArchivoReporte, RutaPDF + "Reporte.pdf",true);
            var rutaArchivoEnviar = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RutaPDF + ArchivoReporte);
            var res = Utilitario.Accion.EnvioCorreo(Detinatario, Asunto, "Reporte ", rutaArchivoEnviar);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GenerarReporte(Reporte_EL R)
        {
            string postdata = JsonConvert.SerializeObject(R);

            var Lis = JsonConvert.DeserializeObject<List<Reporte_EL>>(Utilitario.Accion.Conect_WEBAPI("Reporte/ListarReporte", "POST", postdata));

            return Json(new { listrm = Lis, }, JsonRequestBehavior.AllowGet);
        }



    }

    public class reporteMateriaPrima
    {
        public string vnombremateriaprima { get; set; }
        public string tipopronostico { get; set; }
        public string indicador { get; set; }
    }
    public class reporteACTIVIDADCONTROLPRODUCCION
    {
        public string Tiempoinicial { get; set; }
        public string TiempoFinal { get; set; }
        public string tiempototalmezclado { get; set; }
        public string tiempototalreposo { get; set; }
        public string tiempototalfiltrado { get; set; }
        public string tiempototalllenado { get; set; }
        public string tiempototalencajonado { get; set; }
    }
    public class reporteCAPACITACION
    {
        public string vcodcapacitacion { get; set; }
        public string vtemacapacitacion { get; set; }
        public string dfechapropuestacapacitacion { get; set; }

        public string cantidadcapacitados { get; set; }
        public string cantidad { get; set; }
    }
    public class reportePROVEEDOR
    {
        public string vnombreproveedor { get; set; }
        public string vnombremateriaprima { get; set; }
        public string icondiciones { get; set; }
        public string puntaje { get; set; }
    }
    public class grupoReporte
    {
        public reporteMateriaPrima _reporteMateriaPrima { get; set; }
        public reporteACTIVIDADCONTROLPRODUCCION _reporteACTIVIDADCONTROLPRODUCCION { get; set; }
        public reporteCAPACITACION _reporteCAPACITACION { get; set; }
        public reportePROVEEDOR _reportePROVEEDOR { get; set; }
    }
    public class TrazabilidadSample
    {
        public float producto;
        public float proveedor;
        public float peso;
        public float duracion;
    }
    public class Prediccion
    {
        public float prediccion { get; set; }
        public string rms { get; set; }
        public string Squared { get; set; }
    }
}