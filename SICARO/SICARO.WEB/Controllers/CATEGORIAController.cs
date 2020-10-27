using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICARO.WEB.Controllers
{
    public class CATEGORIAController : Controller
    {
        // GET: CATEGORIA
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListaCategoriaProducto(CATEGORIA_EL ca)
        {
            try
            {
                var Lis = JsonConvert.DeserializeObject<List<CATEGORIA_EL>>(Utilitario.Accion.Conect_WEBAPI("CATEGORIA", "GET", "", "1"));// ca.iIdproducto.ToString()));
                return Json(Lis, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ListaCAPACITACION = "" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}