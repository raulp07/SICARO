using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class PROVEEDOR_MATERIAPRIMA_EL
    {
        public int iIdProveedor { get; set; }
        public int iIdMateriaPrima { get; set; }
        public DateTime dFechaEvaluacion { get; set; }
        public string vNombreProveedor { get; set; }
        public string vNombreMateriaPrima { get; set; }
        public int iUsuario { get; set; }
    }
}