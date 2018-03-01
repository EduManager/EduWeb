using Edu.Infrastructure.Common;
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
    }
}
