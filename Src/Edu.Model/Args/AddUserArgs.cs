using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    [DataContract]
    public class AddUserArgs
    {
        [DataMember]
        public int SchoolId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string UserKey { get; set; }
        [DataMember]
        public string DoorCardNumber { get; set; }
        [DataMember]
        public int CreateBy { get; set; }
        [DataMember]
        public int RegionId { get; set; }
        [DataMember]
        public int RoleId { get; set; }
    }
}
