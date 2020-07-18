using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICARO.WEB.Models
{
    public class CONTROLPRODUCCION_EL
    {

        public int idControlProduccion { get; set; }
        public int tipoPronostico { get; set; }
        public int idProducto { get; set; }
        public int idProveedor { get; set; }
        public int idIntervaloProduccion { get; set; }
        public int idUnidadMedida { get; set; }
        public int idPeso { get; set; }
        public int idActividad { get; set; }
        public int cantidadProducida { get; set; }
        public string PRECISION { get; set; }
        public string ErrorMedioCuadratico { get; set; }
        public int predicion { get; set; }
        public string Color { get; set; }
        public DateTime fechaProduccion { get; set; }
        public string indicador { get; set; }
    }
}