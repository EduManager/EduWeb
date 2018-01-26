using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
