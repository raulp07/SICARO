using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_SICARO.Models
{
    public class pronostico_duracion_insumo_EL
    {
        public int producto { get; set; }
        public int proveedor { get; set; }
        public int unidadmedida { get; set; }
        public int peso { get; set; }
        public int vecesutilizadoprod { get; set; }
        public int tiempo { get; set; }
    }
}