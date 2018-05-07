using Edu.Controller.Common;
using Edu.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Edu.Controller.Controller
{
    [AuthFilter]
    public class EntryController : System.Web.Mvc.Controller
    {
        [AuthFilter]
        public ViewResult SignUp()
        {
            var userId = ApplicationContext.UserId;
            var schoolId = ApplicationContext.SchoolId;
            return View();
        }
    }
}
