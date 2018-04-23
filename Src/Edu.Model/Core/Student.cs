using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class Student : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Sex { get; set; }

        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public string Tel { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int RegionId { get; set; }

        [DataMember]
        public int RegionName { get; set; }
    }
}
