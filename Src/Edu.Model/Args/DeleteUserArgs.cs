using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    [DataContract]
    public class DeleteUserArgs
    {
        [DataMember]
        public int  SchoolId { set; get; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int ModifyBy { get; set; }
    }
}
