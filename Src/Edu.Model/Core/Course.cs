using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class Course : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public int CourseTypeId { get; set; }
        [DataMember]
        public string CourseTypeName { get; set; }

    }
}
