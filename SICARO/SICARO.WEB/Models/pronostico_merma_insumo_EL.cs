using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class pronostico_merma_insumo_EL
    {
        public int producto { get; set; }
        public int proveedor { get; set; }
        public int unidadmedida { get; set; }
        public int peso { get; set; }
        public int merma { get; set; }
    }
}