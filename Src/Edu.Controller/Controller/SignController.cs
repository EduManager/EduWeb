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
    public class SignController : System.Web.Mvc.Controller
    {

        public ViewResult List(int pageIndex = 1)
        {
            var schoolId = ApplicationContext.SchoolId;
            return View();
        }
        [AuthFilter]
        public ViewResult SignUp()
        {
            int pageIndex = 1;
            var userId = ApplicationContext.UserId;
            var schoolId = ApplicationContext.SchoolId;
            var args = new GetObjectsByPagingArgs()
            {
                PageSize = 10,
                SchoolId = schoolId,
                PageIndex = pageIndex,
                WhereStr = "",
                OrderBy = ""
            };
            var result = StudentService.Instance.GetStudentListByPaging(args);
            ViewData["PageCount"] = (args.RowsCount - 1) / args.PageSize + 1;
            ViewData["PageSize"] = args.PageSize;
            ViewData["PageIndex"] = args.PageIndex;
            return View(result.Items);
        }
        [HttpGet]
        public string GetStudentInfo(int stuId)
        {
            if (stuId > 0)
            {
                var result = StudentService.Instance.GetStudentById(new GetObjectByIdArgs()
                {
                    SchoolId = ApplicationContext.SchoolId,
                    OId = stuId
                });

                return JsonHelper.Serialize(result);
            }

            return JsonHelper.Serialize(CommandResult.Failure("id不能为小于0的值"));
        }

        [HttpPost]
        public string QueryStudent(string stuName, string stdPhone, int pageIndex = 1)
        {
            string wherestr = " and st.name like '%" + stuName + "%'";
            if (stdPhone.Trim() != "")
            {
                wherestr = wherestr + " and (right(st.tel1,4)='" + stdPhone + "' or right(st.tel1,4)='" + stdPhone + "' or right(st.tel1,4)='" + stdPhone + "')";
            }
            var schoolId = ApplicationContext.SchoolId;
            var args = new GetObjectsByPagingArgs()
            {
                PageSize = 10,
                SchoolId = schoolId,
                PageIndex = pageIndex,
                WhereStr = wherestr,
                OrderBy = ""
            };
            var result = StudentService.Instance.GetStudentListByPaging(args);
            return JsonHelper.Serialize(result);
        }
        [HttpPost]
        public string uppic(IEnumerable<HttpPostedFileBase> filename, FormCollection form)
        {
            string path = "";
            if (filename == null)
                return "上传失败！";
            foreach (var item in filename)
            {
                var fileName = Path.Combine(Request.MapPath("~/Content/img/upload/"), Path.GetFileName(item.FileName));
                item.SaveAs(fileName);
                path = "/Content/img/upload/" + Path.GetFileName(item.FileName);
            }
            return path;
        }

    }
}
