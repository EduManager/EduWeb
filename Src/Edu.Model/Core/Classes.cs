using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class Classes : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int SchoolRegionId { get; set; }

        [DataMember]
        public string SchoolRegionName { get; set; }

        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public string FeeType { get; set; }

        [DataMember]
        public string UnitPrice { get; set; }

        [DataMember]
        public string ClassHour { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public string Teacher { get; set; }

        [DataMember]
        public int MaxCount { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
