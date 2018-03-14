using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class Bookfee : DomainEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FeeName { get; set; }

        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int FeeType { get; set; }

        [DataMember]
        public int Integration { get; set; }
        
    }
}
