using System.Web;
using Edu.Controller.Common;

namespace Edu.Infrastructure.Common
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
