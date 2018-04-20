using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Edu.Infrastructure.Attrs;

namespace Edu.Model.Bussiness
{
    public class ExcelUserInfo
    {
        [DataMember]
        [ColumnNumber(1)]
        public string Name { get; set; }

        [DataMember]
        [ColumnNumber(2)]
        public string Phone { get; set; }

        [DataMember]
        [ColumnNumber(3)]
        public string Email { get; set; }

        [DataMember]
        [ColumnNumber(4)]
        public string DoorCardNum { get; set; }
        
    }
}
