using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
            var schoolId = ApplicationContext.SchoolId;
            var userId = ApplicationContext.UserId;
            var roleId = ApplicationContext.RoleId;
            var userName = ApplicationContext.UserName;
            bool isRedirct = schoolId == 0 || userId == 0 || roleId == 0 || string.IsNullOrEmpty(userName);

            if (isRedirct)
            {
                filterContext.Result = new RedirectToRouteResult("User", new RouteValueDictionary
                {
                    {
                        "from", HttpContext.Current.Request.Url.ToString()
                    }
                });

            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
