using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class Reporte_EL
    {
        public decimal indice { get; set; }
        public Int16 estado { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechainicial { get; set; }
        public DateTime fechafinal { get; set; }
    }
}