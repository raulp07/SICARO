using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WEBAPI_SICARO.Modles
{
    public class stats
    {
        [DataMember]
        public int approved { get; set; }
        [DataMember]
        public int disapproved { get; set; }
    }
}