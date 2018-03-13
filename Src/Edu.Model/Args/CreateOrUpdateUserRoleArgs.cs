using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class CreateOrUpdateUserRoleArgs
    {
        public int SchoolId { set; get; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int CreateBy { set; get; }
        public int ModifyBy { get; set; }
    }
}
