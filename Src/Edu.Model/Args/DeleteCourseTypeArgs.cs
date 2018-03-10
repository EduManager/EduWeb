using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class DeleteCourseTypeArgs
    {
        public int SchoolId { get; set; }
        public int CourseTypeId { get; set; }
        public int ModifyBy { get; set; }
    }
}
