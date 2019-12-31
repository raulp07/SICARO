using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_SICARO.Models
{
    public class PRODUCTO_MATERIAPRIMA_EL
    {
        public int iIdproducto { get; set; }
        public int iIdMateriaPrima { get; set; }
        public DateTime dFechaEvaluacion { get; set; }

        public string vNombreProducto { get; set; }
        public int iIdProveedor { get; set; }
        public string vNombreProveedor { get; set; }

    }
}