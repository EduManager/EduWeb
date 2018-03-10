using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class UpdateCampusArgs
    {
        public int SchoolId { get; set; }
        public int CampusId { get; set; }
        public string CampusName { get; set; }
        public string CampusType { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Contract { get; set; }
        public string ContractTel { get; set; }

        public int ModifyBy { get; set; }


    }
}
