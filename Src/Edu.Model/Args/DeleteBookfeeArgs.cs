using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class DeleteBookfeeArgs
    {
        public int FeeId { get; set; }
        public int SchoolId { get; set; }
        public int ModifyBy { get; set; }
    }
}
