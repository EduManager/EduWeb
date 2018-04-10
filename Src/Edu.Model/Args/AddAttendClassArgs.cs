using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class AddAttendClassArgs
    {
        public int SchoolId { get; set; }

        public int SchoolRegionId { get; set; }
        
        public int ClassId { get; set; }

        public int BeginWeek { get; set; }

        public int EndWeek { get; set; }

        public string BeginTime { get; set; }
        
        public string EndTime { get; set; }
        
        public string Teacher { get; set; }
        
        public string ClassRoom { get; set; }

        public string Remark { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }

        public int IsDelete { get; set; }
    }
}
