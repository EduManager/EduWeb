using Edu.Controller.Common;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
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
    public class EntryController : System.Web.Mvc.Controller
    {
        [AuthFilter]
        public ViewResult SignUp()
        {
            var userId = ApplicationContext.UserId;
            var schoolId = ApplicationContext.SchoolId;
            return View();
        }
        [HttpPost]
        public string AddEntry(AddEntryArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = EntryService.Instance.AddEntry(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpPost]
        public string AddAccount(AddAccountArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = EntryService.Instance.AddAccount(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }
    }
}
