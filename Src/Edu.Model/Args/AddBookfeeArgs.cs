using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
   public class AddBookfeeArgs
    {
        public int SchoolId { get; set; }

        public int CourseId { get; set; }

        public string FeeName { get; set; }

        public decimal Price { get; set; }

        public int Feetype { get; set; }

        public int Integration { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }
    }
}
