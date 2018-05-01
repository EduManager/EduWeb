using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
  public class UpdateClassesArgs
    {
        public int ClassId { get; set; }

        public int SchoolId { get; set; }

        public int SchoolRegionId { get; set; }

        public string Name { get; set; }
        
        public int CourseId { get; set; }

        public string FeeType { get; set; }

        public decimal UnitPrice { get; set; }

        public int ClassHour { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Teacher { get; set; }

        public int MaxCount { get; set; }

        public int Status { get; set; }

        public string Address { get; set; }
        
        public int ModifyBy { get; set; }
    }
}
