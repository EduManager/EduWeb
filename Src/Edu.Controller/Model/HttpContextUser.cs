using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Edu.Controller.Common;

namespace Edu.Controller.Model
{
    public static class HttpContextUser
    {
        public static int SchoolId
        {
            get
            {
                var objectId = HttpContext.Current.Session[SessionConst.SchoolId];
                if (objectId != null)
                    return (int) objectId;
                return 0;
            }
        }

        public static int UserId
        {
            get
            {
                var objectId = HttpContext.Current.Session[SessionConst.UserId];
                if (objectId != null)
                    return (int)objectId;
                return 0;
            }
        }
        public static int RoleId
        {
            get
            {
                var objectId = HttpContext.Current.Session[SessionConst.RoleId];
                if (objectId != null)
                    return (int)objectId;
                return 0;
            }
        }
        public static string UserName
        {
            get
            {
                var name = HttpContext.Current.Session[SessionConst.UserName];
                if (name != null)
                    return name.ToString();
                return "";
            }
        }
    }
}
