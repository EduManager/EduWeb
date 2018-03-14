using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Core
{
    public class SysConfig : DomainEntity
    {
        public int UserId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
