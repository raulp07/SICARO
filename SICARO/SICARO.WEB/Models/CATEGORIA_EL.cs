using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class CATEGORIA_EL
    {
        public int idCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public int RedInicio { get; set; }
        public int RedFin { get; set; }
        public int YellowInicio { get; set; }
        public int YellowFin { get; set; }
        public int GreenInicio { get; set; }
        public int GreenFin { get; set; }
        public int iIdproducto { get; set; }
    }
}