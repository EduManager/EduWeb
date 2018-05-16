using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class AddStudentArgs
    {
        public int SchoolId { get; set; }

        public int RegionId { get; set; }

        public string Name { get; set; }

        public int Sex { get; set; }

        public DateTime Birthday { get; set; }

        public string FullTimeSchool { get; set; }

        public string Grade { get; set; }

        public string Tel1 { get; set; }

        public string Tel2 { get; set; }

        public string Tel3 { get; set; }

        public string Address { get; set; }

        public string Remark { get; set; }

        public string Picture { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }
    }
}
