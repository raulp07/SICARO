using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WEBAPI_SICARO.Modles
{
    public class OpcionXPerfil_EL 
    {
        [DataMember]
        public Rol_EL Rol { get; set; }

        [DataMember]
        public Opcion_EL Opcion { get; set; }

        [DataMember]
        public bool Escritura { get; set; }

        [DataMember]
        public ICollection<OpcionXPerfil_EL> Hijos { get; set; }
    }
}
