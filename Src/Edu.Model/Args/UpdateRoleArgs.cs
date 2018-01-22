using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class UpdateRoleArgs
    {
        public int  RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ModifyBy { get; set; }
    }
}
