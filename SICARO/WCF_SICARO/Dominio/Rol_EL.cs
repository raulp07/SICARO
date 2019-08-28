using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WCF_SICARO.Dominio
{
    public class Rol_EL 
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
    }
}
