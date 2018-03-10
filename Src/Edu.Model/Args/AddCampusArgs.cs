using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
   public class AddCampusArgs
    {
        public int SchoolId { get; set; }

        public string CampusName { get; set; }

        public string CampusType { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public string Contract { get; set; }

        public string ContractTel { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }
    }
}
