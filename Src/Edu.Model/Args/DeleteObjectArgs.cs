using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    [DataContract]
    public class DeleteObjectArgs
    {
        [DataMember]
        public int  SchoolId { set; get; }
        [DataMember]
        public int ObjectId { get; set; }
        [DataMember]
        public int ModifyBy { get; set; }
    }
}
