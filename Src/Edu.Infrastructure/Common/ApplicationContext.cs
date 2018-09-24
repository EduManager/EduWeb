using System.Web;

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

        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = System.Web.HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip,
                @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
    
}
