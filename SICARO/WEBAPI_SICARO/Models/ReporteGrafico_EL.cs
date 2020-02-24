using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_SICARO.Models
{
    public class ReporteGrafico_EL
    {
        public int totalparticipantes { get; set; }
        public int aprobados { get; set; }
        public int desaprobados { get; set; }
        public string nombrePregunta { get; set; }
        public int idPregunta { get; set; }
        public int numaciertos { get; set; }

    }
}