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
   public class BookfeeController:System.Web.Mvc.Controller
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
}
}
