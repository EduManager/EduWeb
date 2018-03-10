using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
   public class AddCourseTypeArgs
    {
        public int SchoolId { get; set; }

        public string CourseType { get; set; }

        public string Description { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }
    }
}
