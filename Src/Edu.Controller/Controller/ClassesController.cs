using Edu.Controller.Common;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        [ActionName("getAttendClassByClassId")]
        public string getAttendClassByClassId(int classId)
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = ClassesService.Instance.GetAttendClassesByClassId(new GetAttendByClassIdArgs()
            {
                SchoolId = schoolId,
                ClassId= classId
            });
            var cts = new List<AttendClass_min>();
            if (result.Code == 200)
                for (int i = 0; i < result.Items.Count; i++)
                {
                    var ac = result.Items[i];
                    AttendClass_min acm = new AttendClass_min();
                    acm.id = ac.Id;
                    acm.title = ac.Remark;
                    acm.start = ac.BeginTime;
                    acm.end = ac.EndTime;
                    cts.Add(acm);
                }
            return JsonHelper.Serialize(cts);
        }
        [HttpPost]
        public string AddClass(AddClassesArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = ClassesService.Instance.AddClass(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }
    [HttpPost]
    public string AddAtttendClass(AddAttendClassArgs[] models)
    {
        for (int i = 0; i < models.Length; i++)
        {
            AddAttendClassArgs model = models[i];
            if (model != null)
            {
                model.BeginTime = DateTime.Parse(model.BeginTime).ToString("yyyy-MM-dd HH:mm:ss");
                model.EndTime = DateTime.Parse(model.EndTime).ToString("yyyy-MM-dd HH:mm:ss");
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = ClassesService.Instance.AddAttendClass(model);
            }
        }
        return JsonHelper.Serialize(CommandResult.Failure<int>());
    }
    public static DateTime FormatDateTime(DateTime bt_in)
    {
        bool f = true;
        if (bt_in.ToString().IndexOf("/") > -1)
        {
            Console.WriteLine();
            DateTime t = DateTime.Today;
            IFormatProvider culture = new CultureInfo("zh-CN", true);     //这里看时dateseparator   也是斜线...
            f = DateTime.TryParseExact(bt_in.ToString(), "yyyy-MM-dd HH:mm:ss", culture, DateTimeStyles.None, out t);
            if (f)
                return t;

        }
        return bt_in;

    }
}
}
