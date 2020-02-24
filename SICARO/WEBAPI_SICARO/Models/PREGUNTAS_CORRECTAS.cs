using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WEBAPI_SICARO.Modles
{
    public class PREGUNTAS_CORRECTAS
    {

        [DataMember]
        public string titulo { get; set; }
        public string Value { get; set; }

    }
}