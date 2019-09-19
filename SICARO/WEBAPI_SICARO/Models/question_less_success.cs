using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WEBAPI_SICARO.Modles
{
    public class question_less_success
    {
        [DataMember]
        public string question { get; set; }

        [DataMember]
        public string evaluated { get; set; }
    }
}