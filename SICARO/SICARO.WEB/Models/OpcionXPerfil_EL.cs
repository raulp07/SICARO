using System;
using System.Collections.Generic;

namespace SICARO.WEB.Models
{
    public class OpcionXPerfil_EL 
    {
        public Rol_EL Rol { get; set; }
        public Opcion_EL Opcion { get; set; }
        public bool Escritura { get; set; }
        public ICollection<OpcionXPerfil_EL> Hijos { get; set; }
    }
}
