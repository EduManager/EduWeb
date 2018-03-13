using System;
using System.Runtime.Serialization;

namespace Edu.Model
{
    [DataContract]
    public class DomainEntity : IDomainEntity
    {
        [DataMember]
        public int SchoolId { get; set; }

        [DataMember]
        public string CreateBy { get; set; }

        [DataMember]
        public DateTime? CreateTime { get; set; }

        [DataMember]
        public string ModifyBy { get; set; }

        [DataMember]
        public DateTime? ModifyTime { get; set; }

        [DataMember]
        public int IsDelete { get; set; }
    }
}
