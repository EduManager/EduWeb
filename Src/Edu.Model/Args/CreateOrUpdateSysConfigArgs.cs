using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class CreateOrUpdateSysConfigArgs
    {
        public int SchoolId { get; set; }
        public int UserId { get; set; }
        public string SKey { get; set; }
        public string SValue { get; set; }
    }
}
