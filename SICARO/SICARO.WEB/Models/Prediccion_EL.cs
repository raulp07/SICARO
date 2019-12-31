using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class Prediccion_EL
    {
        public int Producto { get; set; }
        public int Proveedor { get; set; }
        public int UnidadMedida { get; set; }
        public int Peso { get; set; }
        public int Tiempo { get; set; }
    }
}