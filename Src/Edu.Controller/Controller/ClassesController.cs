using Edu.Controller.Common;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
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
    [AuthFilter]
    public class ClassesController : System.Web.Mvc.Controller
    {
        public ViewResult List()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = ClassesService.Instance.GetClassesBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var models = new List<Classes>();
            if (result.Code == 200)
                models = result.Items;
            return View(models);
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
