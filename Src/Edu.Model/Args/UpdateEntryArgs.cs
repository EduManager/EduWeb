using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class UpdateEntryArgs
    {
        public int SchoolId { get; set; }
        public int EntryId { get; set; }
        public int Status { get; set; }
        public int ModifyBy { get; set; }


    }
}
