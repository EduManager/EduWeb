using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
   public class AddCourseArgs
    {
        public int SchoolId { get; set; }

        public int CourseTypeId { get; set; }

        public string CourseName { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }
    }
}
