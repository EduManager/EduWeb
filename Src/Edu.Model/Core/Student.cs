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
        public DateTime Birthday { get; set; }

        [DataMember]
        public string FullTimeSchool { get; set; }

        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public string Tel1 { get; set; }

        [DataMember]
        public string Tel2 { get; set; }

        [DataMember]
        public string Tel3 { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Remark { get; set; }

        [DataMember]
        public string Picture { get; set; }

        [DataMember]
        public int RegionId { get; set; }

        [DataMember]
        public string RegionName { get; set; }
    }
}
