using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Edu.Controller.Controller
{
    public class BookfeeController : System.Web.Mvc.Controller
    {
        public ViewResult List()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = BookfeeService.Instance.GetFeeBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var fees = new List<Bookfee>();
            if (result.Code == 200)
                fees = result.Items;
            return View(fees);
        }
        [HttpPost]
        public string AddBookfee(AddBookfeeArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = BookfeeService.Instance.AddBookfee(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpDelete]
        public string DeleteBookfeee(int ctId)
        {
            var result = BookfeeService.Instance.DeleteBookfee(new DeleteBookfeeArgs()
            {
                SchoolId = ApplicationContext.SchoolId,
                FeeId = ctId,
                ModifyBy = ApplicationContext.UserId
            });
            return JsonHelper.Serialize(result);
        }

        [HttpPut]
        public string UpdateBookfee(UpdateBookfeeArgs model)
        {
            if (model != null)
            {
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;
                var result = BookfeeService.Instance.UpdateBookfee(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpPost]
        public string getAllCourseTypes()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = CourseService.Instance.GetCourseTypeBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var cts = new List<CourseType>();
            if (result.Code == 200)
                cts = result.Items;
            return JsonHelper.Serialize(cts);
        }
        [HttpPost]
        public string getCourses(int CourseTypeId)
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = CourseService.Instance.GetCourseBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var cts = new List<Course>();
            if (result.Code == 200)
                cts = result.Items;
            cts = cts.Where(a => a.CourseTypeId == CourseTypeId).ToList();
            return JsonHelper.Serialize(cts);
        }
    }
}
