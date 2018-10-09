using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Services;

namespace Edu.Controller.Common
{
    public static class WebApplicationContext
    {
        public static string RoleMenuList
        {
            get
            {
                if (ApplicationContext.RoleId == 0)
                    return JsonHelper.Serialize(new List<RoleMenuItem>());
                var result = RoleMenuService.Instance.GetRoleMenuByRoleId(new GetObjectByIdArgs()
                {
                    OId = ApplicationContext.RoleId,
                    SchoolId = ApplicationContext.SchoolId
                });
                var model = result.Code == 200 ? result.Items : new List<RoleMenuItem>();
                return JsonHelper.Serialize(model);
            }
        }

        public static string ImgPath
        {
            get
            {
                var schools = SysConfigService.Instance.GetSchoolInfoById(new GetObjectByIdArgs()
                {
                    SchoolId = ApplicationContext.SchoolId
                });
                if (schools.Code == 200)
                {
                    var school = schools.Items.FirstOrDefault();
                    if (school != null) return school.ImgPath;
                }
                return "";
            }
        }
    }
    
}
