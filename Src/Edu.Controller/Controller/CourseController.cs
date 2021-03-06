﻿using Edu.Infrastructure.Common;
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
using Edu.Controller.Common;

namespace Edu.Controller.Controller
{
    [AuthFilter]
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

        public ViewResult CourseList()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = CourseService.Instance.GetCourseBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var cts = new List<Course>();
            if (result.Code == 200)
                cts = result.Items;
            return View(cts);
        }
        [HttpPost]
        public string AddCourseType(AddCourseTypeArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = CourseService.Instance.AddCourseType(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpDelete]
        public string DeleteCourseType(int ctId)
        {
            var result = CourseService.Instance.DeleteCourseType(new DeleteObjectArgs()
            {
                SchoolId = ApplicationContext.SchoolId,
                ObjectId = ctId,
                ModifyBy = ApplicationContext.UserId
            });
            return  JsonHelper.Serialize(result);
        }

        [HttpPut]
        public string UpdateCourseType(UpdateCourseTypeArgs model)
        {
            if (model != null)
            {
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;
                var result = CourseService.Instance.UpdateCourseType(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpPost]
        public string AddCourse(AddCourseArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = CourseService.Instance.AddCourse(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpDelete]
        public string DeleteCourse(int ctId)
        {
            var result = CourseService.Instance.DeleteCourse(new DeleteObjectArgs()
            {
                SchoolId = ApplicationContext.SchoolId,
                ObjectId = ctId,
                ModifyBy = ApplicationContext.UserId
            });
            return JsonHelper.Serialize(result);
        }

        [HttpPut]
        public string UpdateCourse(UpdateCourseArgs model)
        {
            if (model != null)
            {
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;
                var result = CourseService.Instance.UpdateCourse(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpPost]
        [ActionName("getAllCourseTypes")]
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
        [ActionName("getCourses")]
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
