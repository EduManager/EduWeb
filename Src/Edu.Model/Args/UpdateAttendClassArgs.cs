using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class UpdateAttendClassArgs
    {
        public int AttendClassId { get; set; }
        
        public int SchoolId { get; set; }

        public DateTime BeginTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public string Teacher { get; set; }
        
        public string ClassRoom { get; set; }

        public string Remark { get; set; }

        public int ModifyBy { get; set; }
        
    }
}
