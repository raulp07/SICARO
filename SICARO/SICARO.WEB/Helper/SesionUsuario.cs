using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class SesionUsuario
    {
        #region "Propiedades"

        public static USUARIO_EL Usuario
        {
            get { return Obtener<USUARIO_EL>("entrada"); }
            set { Asignar("entrada", value); }
        }

        public static List<OpcionXPerfil_EL> MenuRoot
        {
            get { return Obtener<List<OpcionXPerfil_EL>>("MenuRoot"); }
            set { Asignar("MenuRoot", value); }
        }

        public static String UrlSite
        {
            get { return ConfigurationManager.AppSettings["urlSite"].ToString(); }
        }

        public static AplicacionEL Aplicacion
        {
            get { return Obtener<AplicacionEL>("aplicationWeb"); }
            set { Asignar("aplicationWeb", value); }
        }

        private static void Asignar(string key, object value)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, value);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        private static T Obtener<T>(string key)
        {
            var x = new HttpContextWrapper(HttpContext.Current);
            var y = x.Session[key];

            return (T)HttpContext.Current.Session[key];
        }
        #endregion

    }
}