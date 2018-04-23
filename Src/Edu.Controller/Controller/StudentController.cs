using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Edu.Controller.Common;
using Edu.Controller.Model;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Services;

namespace Edu.Controller.Controller
{
    [AuthFilter]
    public class StudentController : System.Web.Mvc.Controller
    {

        public ViewResult List(int pageIndex = 1)
        {
            var schoolId = ApplicationContext.SchoolId;
            var args = new GetObjectsByPagingArgs()
            {
                PageSize = 10,
                SchoolId = schoolId,
                PageIndex = pageIndex,
                WhereStr = "",
                OrderBy = ""
            };
            var result = UserService.Instance.GetUserInfoByPaging(args);
            ViewData["PageCount"] = args.RowsCount / args.PageSize + 1;
            ViewData["PageSize"] = args.PageSize;
            ViewData["PageIndex"] = args.PageIndex;

            return View(result.Items);
        }

        public string GetStudents()
        {
            return "";
        }
    }
}
