using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class Campus : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CampusName { get; set; }

        [DataMember]
        public int CampusType { get; set; }

        [DataMember]
        public string Tel { get; set; }

        [DataMember]
        public string Address{ get; set; }

        [DataMember]
        public string Contract { get; set; }

        [DataMember]
        public string ContractTel { get; set; }

        [DataMember]
        public int SchoolId { get; set; }

        [DataMember]
        public string SchoolName { get; set; }
            }
}
