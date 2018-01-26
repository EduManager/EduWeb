using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Edu.Controller.Common;
using Edu.Controller.Model;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Services;

namespace Edu.Controller.Controller
{
    public class UserController : System.Web.Mvc.Controller
    {
        public ViewResult Login()
        {
            SetToken();
            return View();
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            var from = Request.UrlReferrer.AbsoluteUri.Contains("from")
                ? Request.UrlReferrer.AbsoluteUri.Substring(Request.UrlReferrer.AbsoluteUri.IndexOf('=')+1)
                : "";
            try
            {
                if (Request.Cookies.AllKeys.Contains("TOKEN") && Request.Form.AllKeys.Contains("Account") &&
                    Request.Form.AllKeys.Contains("Password"))
                {
                    var accoutS = Request["Account"];
                    var passwordS = Request["Password"];
                    var key = Request.Cookies["TOKEN"];
                    var iv = Request.Cookies["IV"];
                    var loginInfo = new LoginUserInfo()
                    {
                        Account = accoutS,
                        Password = passwordS
                    };
                    if (key != null && iv != null)
                    {
                        var account = DesEncryptHelper.Decrypt3Des(loginInfo.Account, key.Value, CipherMode.CBC,
                            iv.Value);
                        var password = DesEncryptHelper.Decrypt3Des(loginInfo.Password, key.Value, CipherMode.CBC,
                            iv.Value);
                        //获取用户信息
                        var userInfo = UserService.Instance.GetUserInfoByLoginInAccount(new LoginInArgs()
                        {
                            Account = account
                        });
                        if (userInfo.Code == 200)
                        {
                            var user = userInfo.Items.FirstOrDefault();
                            if (user != null)
                            {
                                //通过用户的token解密用户密码，然后跟此次输入密码比对
                                var userToken = user.Token.Substring(0, 24);
                                var userIv = user.Token.Substring(24, 8);
                                var userPassword = DesEncryptHelper.Decrypt3Des(user.Password, userToken, CipherMode.ECB,
                                    userIv);
                                if (userPassword == password)
                                {
                                    ApplicationContext.RoleId = user.RoleId;
                                    ApplicationContext.SchoolId = user.SchoolId;
                                    ApplicationContext.UserId = user.UserId;
                                    ApplicationContext.UserName = user.Name;
                                    if (!string.IsNullOrEmpty(from))
                                        return Redirect(from);
                                    return RedirectToAction("Index", "Home");
                                }
                                ViewBag.Msg = "用户密码错误";
                            }
                            else
                            {
                                ViewBag.Msg = "用户不存在";
                            }
                        }
                        else
                        {

                            ViewBag.Msg = userInfo.Message;
                        }
                    }
                    else
                    {
                        ViewBag.Msg = "页面数据异常，请刷新页面";
                    }
                }
                else
                {
                    ViewBag.Msg = "令牌格式错误";
                }

                SetToken();
                return View("Login");
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), e.ToString(), e);
                ViewBag.Msg = "用户登录异常";
                SetToken();
                return View("Login");
            }
        }

        private void SetToken()
        {
            var timespan = DateTime.Now.ToLongTime().ToString();
            var token = Guid.NewGuid().ToString().Replace("-", "");
            var key = token.Substring(0, 24);
            var iv = timespan.Substring(2, 8);
            ViewBag.Secret = key;
            ViewBag.IV = iv;
            HttpCookie tokenCookie = new HttpCookie("TOKEN", key);
            HttpCookie keyCookie = new HttpCookie("IV", iv);
            tokenCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(tokenCookie);
            Response.Cookies.Add(keyCookie);
        }
    }
}
