using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model.Args;
using Edu.Services;

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

            if (true)
            {
                //判断cookie中是否包含登陆信息
                bool isRealRedirect = true;
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("LoginToken") &&
                    HttpContext.Current.Request.Cookies.AllKeys.Contains("UserCookie"))
                {
                    var loginCookie = HttpContext.Current.Request.Cookies["LoginToken"];
                    var userCookie = HttpContext.Current.Request.Cookies["UserCookie"];

                    if (userCookie != null && loginCookie!=null)
                    {
                        var userInfoArray = userCookie.Value.Split('&');
                        if (userInfoArray.Length == 2)
                        {
                            if (int.TryParse(userInfoArray[0], out userId) && int.TryParse(userInfoArray[1], out schoolId))
                            {
                                var userInfos = UserService.Instance.GetUserInfoByUserId(new GetObjectByIdArgs()
                                {
                                    SchoolId = schoolId,
                                    Id = userId
                                });
                                if (userInfos.Code == 200)
                                {
                                    var user = userInfos.Items.FirstOrDefault();
                                    if (user != null)
                                    {
                                        var userToken = user.Token.Substring(0, 24);
                                        var userIv = user.Token.Substring(24, 8);
                                        var loginInfo = DesEncryptHelper.Decrypt3Des(loginCookie.Value, userToken, CipherMode.ECB,
                                            userIv);
                                        var loginInfoArray = loginInfo.Split('&');
                                        int roleId2, schoolId2, userId2;
                                        //验证cookie是否造假
                                        if (loginInfoArray.Length == 3 && int.TryParse(loginInfoArray[0], out roleId2) &&
                                            int.TryParse(loginInfoArray[1], out schoolId2) &&
                                            int.TryParse(loginInfoArray[2], out userId2))
                                        {
                                            if (schoolId2 == schoolId && userId2 == userId)
                                            {
                                                ApplicationContext.SchoolId = schoolId;
                                                ApplicationContext.UserId = userId;
                                                ApplicationContext.RoleId = roleId2;
                                                ApplicationContext.UserName = user.Name;

                                                //记录登陆信息
                                                var Ip = ApplicationContext.GetHostAddress();
                                                Task.Factory.StartNew(obj =>
                                                {
                                                    var o = (dynamic)obj;
                                                    //存入数据库
                                                    UserService.Instance.AddUserLoginLog(new AddUserLoginLogArgs()
                                                    {
                                                        UserId = o.UserId,
                                                        SchoolId = o.SchoolId,
                                                        LoginIp = o.Ip
                                                    });
                                                }, new { Ip, user.UserId, ApplicationContext.SchoolId });

                                                isRealRedirect = false;
                                                base.OnActionExecuting(filterContext);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //是否跳转
                if (isRealRedirect)
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
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
