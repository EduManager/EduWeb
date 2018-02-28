using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.Args
{
    public class GetUserInfoByPagingArgs
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int RowsCount { get; set; }

        public string OrderBy { get; set; }

        public string WhereStr { get; set; }
    }
}
