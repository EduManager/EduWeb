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
        }
    }
    
}
