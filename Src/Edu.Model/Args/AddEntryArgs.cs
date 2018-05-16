using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class AddEntryArgs
    {
        public int SchoolId { get; set; }

        public int RegionId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int ClassId { get; set; }

        public string FullName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CourseHour { get; set; }

        public int Status { get; set; }

        public string Remain { get; set; }

        public string Ext1 { get; set; }

        public string Ext2 { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }

    }
}
