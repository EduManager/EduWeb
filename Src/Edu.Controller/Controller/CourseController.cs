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
    public class CourseController : System.Web.Mvc.Controller
    {
        public ViewResult CourseTypeList()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = CourseService.Instance.GetCourseTypeBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var cts = new List<CourseType>();
            if (result.Code == 200)
                cts = result.Items;
            return View(cts);
        }

        [HttpPost]
        public string Add(AddCourseTypeArgs model)
        {
            //if (model != null)
            //{
            //    model.CreateBy = ApplicationContext.UserId;
            //    model.ModifyBy = ApplicationContext.UserId;
            //    model.SchoolId = ApplicationContext.SchoolId;

            //    var result = CampusService.Instance.AddCampus(model);
            //    return JsonHelper.Serialize(result);
            //}
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpDelete]
        public string Delete(int campusId)
        {
            //var result = CampusService.Instance.DeleteCampus(new DeleteCampusArgs()
            //{
            //    SchoolId = ApplicationContext.SchoolId,
            //    CampusId = campusId,
            //    ModifyBy = ApplicationContext.UserId
            //});
            return "";// JsonHelper.Serialize(result);
        }

        [HttpPut]
        public string Update(UpdateCourseTypeArgs model)
        {
            //if (model != null)
            //{
            //    model.ModifyBy = ApplicationContext.UserId;
            //    model.SchoolId = ApplicationContext.SchoolId;
            //    var result = CampusService.Instance.UpdateCampus(model);
            //    return JsonHelper.Serialize(result);
            //}
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

    }
}
