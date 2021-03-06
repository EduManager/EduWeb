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
        [ActionName("getBookFeeByCourse")]
        public string getBookFeeByCourse(int courseId)
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = BookfeeService.Instance.GetFeeBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var models = new List<Bookfee>();
            if (result.Code == 200)
            {
                models = result.Items;
                models = models.Where(p => p.CourseId == courseId).ToList();
            }
            return JsonHelper.Serialize(models);
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
            var result = BookfeeService.Instance.DeleteBookfee(new DeleteObjectArgs()
            {
                SchoolId = ApplicationContext.SchoolId,
                ObjectId = ctId,
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

    }
}
