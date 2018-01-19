using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.Procedure
{
    public class AddRoleMenuArgs
    {
        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }
    }
}
