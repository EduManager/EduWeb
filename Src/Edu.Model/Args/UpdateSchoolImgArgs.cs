using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    [DataContract]
    public class UpdateSchoolImgArgs
    {

        [DataMember]
        public int SchoolId { get; set; }
        
        [DataMember]
        public string ImgPath { get; set; }
    }
}
