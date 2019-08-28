using SICARO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SICARO.WEB.Controllers
{
    public class LoginController : Controller
    {

        JavaScriptSerializer js = new JavaScriptSerializer();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ValidarUsuario(USUARIO_EL Ususario)
        {
            try
            {
                List<USUARIO_EL> ListaCAPACITACION = new List<USUARIO_EL>();
                string postdata = js.Serialize(Ususario);
                ListaCAPACITACION = js.Deserialize<List<USUARIO_EL>>(Utilitario.Accion.ConectREST("GETUSUARIO", "POST", postdata));
                                
                if (ListaCAPACITACION.Count>0)
                {
                    Rol_EL rol = new Rol_EL() { Id = ListaCAPACITACION[0].IdRol };
                    
                    SesionUsuario.MenuRoot = SetearMenu(rol,false);
                    return Json(ListaCAPACITACION, JsonRequestBehavior.AllowGet);
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


        #region Metodos
        

        public static List<OpcionXPerfil_EL> SetearMenu(Rol_EL Rol,bool padre)
        {
            List<OpcionXPerfil_EL> lista = null;
            OpcionXPerfil_EL opcionesXPerfil = new OpcionXPerfil_EL()
            {
                Rol = Rol
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postdata = js.Serialize(opcionesXPerfil);
            lista = js.Deserialize<List<OpcionXPerfil_EL>>(Utilitario.Accion.ConectREST("ListaMenu", "POST", postdata));  //menuBL.ListMenu(opcionesXPerfil);

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

        #endregion

    }
}