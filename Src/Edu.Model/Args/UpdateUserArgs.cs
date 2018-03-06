using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    [DataContract]
    public class UpdateUserArgs
    {

        [DataMember]
        public int SchoolId { get; set; }

        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public int ModifyBy { get; set; }
    }
}
