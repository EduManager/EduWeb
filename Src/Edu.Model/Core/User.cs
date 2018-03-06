using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Edu.Model.Core
{
    [DataContract]
    public class User : DomainEntity
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int SchoolId { get; set; }

        [DataMember]
        public string SchoolName { get; set; }

        [DataMember]
        public int RegionId { get; set; }

        [DataMember]
        public string Campname { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string DoorCardNum { get; set; }

        [DataMember]
        public string Email { get; set; }
        
        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }
    }
}
