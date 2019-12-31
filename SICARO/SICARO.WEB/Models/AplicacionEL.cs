using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class AplicacionEL
    {
        public int Id { get; set; }
        public ParametroEL TipoAplicacion { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}