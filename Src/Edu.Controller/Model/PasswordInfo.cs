using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Controller.Model
{
    [DataContract]
    public class PasswordInfo
    {
        [DataMember]
        public string OriginalPassword { get; set; }

        [DataMember]
        public string NewPassword { get; set; }
    }
}
