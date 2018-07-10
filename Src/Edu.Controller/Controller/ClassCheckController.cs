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
    public class ClassCheckController : System.Web.Mvc.Controller
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
        [ActionName("getClass")]
        public string getClass(int courseId,int campusId)
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = ClassesService.Instance.GetClassesBySchoolId(new GetObjectByIdArgs()
            {
                SchoolId = schoolId
            });
            var models = new List<Classes>();
            if (result.Code == 200)
                models = result.Items;
            if (courseId != -1)
            {
                models = models.Where(p => p.CourseId == courseId).ToList();

            }
            if (campusId != -1)
            {
                models = models.Where( p.SchoolRegionId == campusId).ToList();
            }
            return JsonHelper.Serialize(models);
        }
    }
}
