using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class AddAccountArgs
    {
        public int SchoolId { get; set; }

        public int RegionId { get; set; }

        public int EntryId { get; set; }

        public decimal ShouldExpenses { get; set; }

        public decimal BookExpenses { get; set; }

        public decimal OtherExpenses { get; set; }

        public decimal RealExpenses { get; set; }

        public int OptType { get; set; }

        public string Optor { get; set; }
        
        public string Remark { get; set; }

        public int DiscountType { get; set; }

        public string DiscountExpenses { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }

    }
}
