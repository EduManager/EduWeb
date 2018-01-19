using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Edu.Controller.Common
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //权限逻辑
            var cookies = HttpContext.Current.Request.Cookies;
            var session = HttpContext.Current.Session;
            var cookieSchoolId = cookies[SessionConst.SchoolId];
            var sessionSchoolId = session[SessionConst.SchoolId];

            var cookieUserId = cookies[SessionConst.UserId];
            var sessionUserId = session[SessionConst.UserId];

            var cookieRoleId = cookies[SessionConst.RoleId];
            var sessionRoleId = session[SessionConst.RoleId];

            var cookieUserName = cookies[SessionConst.UserName];
            var sessionUserName = session[SessionConst.UserName];
            bool isRedirct = cookieSchoolId == null || sessionSchoolId == null ||
                             cookieSchoolId.ToString() != sessionSchoolId.ToString() ||
                             cookieUserId == null || sessionUserId == null ||
                              cookieUserId.ToString() != sessionUserId.ToString() ||
                             cookieRoleId == null || sessionRoleId == null ||
                              cookieRoleId.ToString() != sessionRoleId.ToString() ||
                             cookieUserName == null || sessionUserName == null ||
                              cookieUserName.ToString() != sessionUserName.ToString();
            //先查询session中的用户信息


            //解密判断客户
            var enSchoolId = cookieSchoolId.ToString();

            var enUserId = cookieUserId.ToString();

            var enRoleId = cookieRoleId.ToString();

            var enUserName = cookieUserName.ToString();


            base.OnActionExecuting(filterContext);
        }
    }
}
