using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class Role : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int SchoolId { get; set; }

        [DataMember]
        public string SchoolName { get; set; }

        [DataMember]
        public string Description { get; set; }

      
    }
}
