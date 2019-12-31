using Newtonsoft.Json;
using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace SICARO.WEB.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Usuario()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Usuario(USUARIO_EL Ususario)
        {
            try
            {
                string mensaje = "";
                if (IsValid(Ususario.CtaUsuario,Ususario.Contrasenia))
                {
                    int codApp;
                    Int32.TryParse(Constantes.CodigoAplicacion, out codApp);
                    string postdata = JsonConvert.SerializeObject(Ususario);
                    List<USUARIO_EL> ListaCAPACITACION = JsonConvert.DeserializeObject<List<USUARIO_EL>>(Utilitario.Accion.Conect_WEBAPI("USUARIO/ValidarUsuario", "POST", postdata));

                    if (ListaCAPACITACION.Count > 0)
                    {
                        mensaje = "Exito";
                        USUARIO_EL resultado = null;
                        resultado = ListaCAPACITACION[0]; 
                        PerfilEL rol = new PerfilEL() { Id = resultado.IdRol };

                        FormsAuthentication.SetAuthCookie(Ususario.CtaUsuario, true);
                        SesionUsuario.Usuario = resultado;
                        SesionUsuario.Aplicacion = new AplicacionEL() { Id = codApp };      
                        SesionUsuario.MenuRoot = SetearMenu(rol, false);

                        return Json(ListaCAPACITACION, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            var entrada = SesionUsuario.Usuario;

            if (entrada != null)
            {
                SesionUsuario.Usuario = null;
                SesionUsuario.MenuRoot = null;
            }

            FormsAuthentication.SignOut();

            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        #region Metodos


        public static List<OpcionXPerfil_EL> SetearMenu(PerfilEL Rol,bool padre)
        {
            OpcionXPerfil_EL opcionesXPerfil = new OpcionXPerfil_EL()
            {
                Rol = Rol
            };
            string postdata = JsonConvert.SerializeObject(opcionesXPerfil);
            var lista = JsonConvert.DeserializeObject<List<OpcionXPerfil_EL>>(Utilitario.Accion.Conect_WEBAPI("OpcionXPerfil", "GET", "", opcionesXPerfil.Rol.Id.ToString()));  //menuBL.ListMenu(opcionesXPerfil);

            List<OpcionXPerfil_EL> menuArbol = new List<OpcionXPerfil_EL>();
            //primero seteamos los padres
            foreach (OpcionXPerfil_EL m in lista.Where(x => x.Opcion.PadreId == 0))
            {
                AsignarMenu(menuArbol, m);
            }
            //seteamos los hijos
            if (!padre)
            {
                foreach (OpcionXPerfil_EL m in lista.Where(x => x.Opcion.PadreId != 0))
                {
                    AsignarMenu(menuArbol, m);
                }
            }

            return menuArbol;
        }

        // Arma el arbol de menus del usuario.
        private static bool AsignarMenu(List<OpcionXPerfil_EL> menuLista, OpcionXPerfil_EL opcionXPerfil)
        {
            if (menuLista == null)
                return false;

            if (opcionXPerfil.Opcion.PadreId == 0)
            {
                menuLista.Add(opcionXPerfil);
                return true;
            }

            bool agregado = false;
            foreach (var m in menuLista)
            {
                if (m.Opcion.Id == opcionXPerfil.Opcion.PadreId)
                {
                    if (m.Hijos == null)
                        m.Hijos = new List<OpcionXPerfil_EL>();
                    m.Hijos.Add(opcionXPerfil);
                    agregado = true;
                    break;
                }
            }

            if (!agregado)
            {
                foreach (var m in menuLista)
                {
                    //agregado = AsignarMenu(m.Hijos, opcion);
                    if (agregado)
                        break;
                }
            }

            return agregado;
        }

        private bool IsValid(string usuario, string pass)
        {
            bool valido = false;
            if (usuario != null || pass != null)
            {
                valido = true;
            }
            return valido;
        }

        #endregion

    }
}