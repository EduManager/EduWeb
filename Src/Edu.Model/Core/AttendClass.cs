using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class AttendClass : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int SchoolRegionId { get; set; }

        [DataMember]
        public int ClassId { get; set; }

        [DataMember]
        public int BeginWeek { get; set; }

        [DataMember]
        public int EndWeek { get; set; }

        [DataMember]
        public string Remark { get; set; }

        [DataMember]
        public DateTime BeginTime { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public string Teacher { get; set; }

        [DataMember]
        public string ClassRoom { get; set; }
        
    }

}
