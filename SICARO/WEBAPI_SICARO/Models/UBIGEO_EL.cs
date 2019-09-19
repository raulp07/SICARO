using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WEBAPI_SICARO.Modles
{
    public class UBIGEO_EL
    {
        
        [DataMember]
        public string co_ubigeo { get; set; }
        [DataMember]
        public string de_ubigeo { get; set; }
        [DataMember]
        public string ti_ubigeo { get; set; }
        [DataMember]
        public string fg_ubigeo { get; set; }
        [DataMember]
        public string st_ubigeo { get; set; }
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string flag { get; set; }
    }
}