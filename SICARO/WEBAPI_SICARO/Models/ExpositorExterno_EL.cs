using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_SICARO.Models
{
    public class ExpositorExterno_EL
    {
        public int iIdExpositorExterno { get; set; }
        public string NombreEmpresa { get; set; }
        public string RUC { get; set; }
        public string Telefono { get; set; }
        public string NombreExpositor { get; set; }
        public string ApellidoPaternoExpositor { get; set; }
        public string ApellidoMaternoExpositor { get; set; }
        public string TipoDocumentoExpositor { get; set; }
        public string NroDocumentoExpositor { get; set; }
        public string TelefonoExpositor { get; set; }
    }
}