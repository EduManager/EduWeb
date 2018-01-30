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
                var result = RoleMenuService.Instance.GetRoleMenuByRoleId(new GetRoleMenuByRoleIdArgs()
                {
                    RoleId = ApplicationContext.RoleId
                });
                var model = result.Code == 200 ? result.Items : new List<RoleMenuItem>();
                return JsonHelper.Serialize(model);
            }
        }
        
    }
    
}
