using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public JsonResult ListaMateriaPrima(MATERIA_PRIMA_EL MP)
        {
            try
            {
                //string postdata = js.Serialize(MP);

                var ListaMATERIA_PRIMA = js.Deserialize<List<MATERIA_PRIMA_EL>>(Utilitario.Accion.Conect_WEBAPI("MATERIA_PRIMA", "GET", "", 0));
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
                var ListaMATERIA_PRIMAProveedor = js.Deserialize<List<PROVEEDOR_EL>>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "GET", "", 0));

                //string postdata = JsonConvert.SerializeObject(MP);
                //var data = JsonConvert.DeserializeObject<List<PROVEEDOR_EL>>(Utilitario.Accion.Conect_WEBAPI("PROVEEDOR", "GET", "", MP.iIdProveedor));

                return Json(new { ListaMATERIA_PRIMAProveedor = ListaMATERIA_PRIMAProveedor }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaMATERIA_PRIMAProveedor = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GuardarPronosticos(PRONOSTICO_EL P)
        {
            try
            {
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("http://127.0.0.1:5000/");

                //byte[]  buffer = Encoding.UTF8.GetBytes("{}");
                //ByteArrayContent byteContent = new ByteArrayContent(buffer);
                //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //var request = clientHttp.PostAsync("api/MATERIA_PRIMA", byteContent).Result;


                var request = clientHttp.GetAsync("escenario1?producto=1&proveedor=1&unidadmedida=1&peso=15").Result;
                var resultado = request.Content.ReadAsStringAsync().Result;

                //var resultado = clientHttp.PostAsync("api/MATERIA_PRIMA?value=1").Result;

                //string postdata = js.Serialize(P);
                //int resultado = js.Deserialize<int>(Utilitario.Accion.Conect_WEBAPI("IPRONOSTICO", "POST", postdata));
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { resultado = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}