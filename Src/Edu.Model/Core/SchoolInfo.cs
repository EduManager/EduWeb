using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    [DataContract]
    public class SchoolInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public string Address { get; set; }

        public string Tel { get; set; }

        public int Status { get; set; }

        public string Contract { get; set; }

        public string ContractTel { get; set; }

        public string ImgPath { get; set; }
    }
}
