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
    public class CampusController : System.Web.Mvc.Controller
    {
        public ViewResult List()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = CampusService.Instance.GetCampusBySchoolId(new GetObjectByIdArgs()
            {
                Id = schoolId
            });
            var roles = new List<Campus>();
            if (result.Code == 200)
                roles = result.Items;
            return View(roles);
        }

        [HttpPost]
        public string Add(AddCampusArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = CampusService.Instance.AddCampus(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpDelete]
        public string Delete(int campusId)
        {
            var result = CampusService.Instance.DeleteCampus(new DeleteCampusArgs()
            {
                SchoolId = ApplicationContext.SchoolId,
                CampusId = campusId,
                ModifyBy = ApplicationContext.UserId
            });
            return JsonHelper.Serialize(result);
        }

        [HttpPut]
        public string Update(UpdateCampusArgs model)
        {
            if (model != null)
            {
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;
                var result = CampusService.Instance.UpdateCampus(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

    }
}
