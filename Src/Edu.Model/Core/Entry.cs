using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class Entry : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RegionId { get; set; }
        [DataMember]
        public string RegionName { get; set; }
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public int ClassId { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public string Teacher { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string OperatorName { get; set; }
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public int Sex { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Tel { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public string ClassFullName { get; set; }
        [DataMember]
        public decimal Remain { get; set; }
        [DataMember]
        public decimal RealExpenses { get; set; }
        [DataMember]
        public decimal BookExpenses { get; set; }
        [DataMember]
        public decimal OtherExpenses { get; set; }
        [DataMember]
        public DateTime? opttime { get; set; }


    }
}
