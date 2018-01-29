using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Edu.Infrastructure.Helper;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Services;

namespace Edu.Controller.Common
{
    public static class ApplicationContext
    {
        public static int SchoolId
        {
            get
            {
                var obj = HttpContext.Current.Session[SessionConst.SchoolId];
                if (obj == null)
                    return 0;
                return (int)obj;
            }
            set { HttpContext.Current.Session[SessionConst.SchoolId] = value; }
        }

        public static int RoleId
        {
            get
            {
                var obj = HttpContext.Current.Session[SessionConst.RoleId];
                if (obj == null)
                    return 0;
                return (int)obj;
            }
            set { HttpContext.Current.Session[SessionConst.RoleId] = value; }
        }

        public static string RoleMenuList
        {
            get
            {
                if (RoleId == 0)
                    return JsonHelper.Serialize(new List<RoleMenuItem>());
                var result = RoleMenuService.Instance.GetRoleMenuByRoleId(new GetRoleMenuByRoleIdArgs()
                {
                    RoleId = RoleId
                });
                var model = result.Code == 200 ? result.Items : new List<RoleMenuItem>();
                return JsonHelper.Serialize(model);
            }
        }

        public static int UserId
        {
            get
            {
                var obj = HttpContext.Current.Session[SessionConst.UserId];
                if (obj == null)
                    return 0;
                return (int)obj;
            }
            set { HttpContext.Current.Session[SessionConst.UserId] = value; }
        }

        public static string UserName
        {
            get
            {
                var obj = HttpContext.Current.Session[SessionConst.UserName];
                if (obj == null)
                    return "";
                return obj.ToString();
            }
            set { HttpContext.Current.Session[SessionConst.UserName] = value; }
        }
    }
    
}
