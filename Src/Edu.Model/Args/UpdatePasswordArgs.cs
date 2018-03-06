using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class UpdatePasswordArgs
    {
        public int SchoolId { get; set; }

        public int UserId { get; set; }
        
        public string Password { get; set; }

        public int ModifyBy { get; set; }
    }
}
