using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI_SICARO.Models
{
    public class pronostico_cantidad_producida_EL
    {
        public int producto { get; set; }
        public int actividad { get; set; }
        public int cantidad { get; set; }
        public int tiempo { get; set; }
    }
}