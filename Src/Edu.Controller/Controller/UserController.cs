﻿using System;
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
using Edu.Model.Core;
using Edu.Services;

namespace Edu.Controller.Controller
{
    public class UserController : System.Web.Mvc.Controller
    {
        #region 登陆相关

        public ViewResult Login()
        {
            SetToken();
            return View();
        }

        public ActionResult SignOut()
        {
            ApplicationContext.UserId = 0;
            ApplicationContext.RoleId = 0;
            ApplicationContext.SchoolId = 0;
            ApplicationContext.UserName = null;
            SetToken();
            return View("Login");
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            var from = Request.UrlReferrer != null && Request.UrlReferrer.AbsoluteUri.Contains("from")
                ? Request.UrlReferrer.AbsoluteUri.Substring(Request.UrlReferrer.AbsoluteUri.IndexOf('=') + 1)
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
                        var account = loginInfo.Account;
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
                                    var Ip = ApplicationContext.GetHostAddress();
                                    //记录登陆信息
                                    var addLogResult = Task.Factory.StartNew(obj =>
                                    {
                                        var o = (dynamic) obj;
                                        //存入数据库
                                        return UserService.Instance.AddUserLoginLog(new AddUserLoginLogArgs()
                                        {
                                            UserId = o.UserId,
                                            SchoolId = o.SchoolId,
                                            LoginIp = o.Ip
                                        });
                                    }, new {Ip, user.UserId,user.SchoolId}).Result;

                                    if (!string.IsNullOrEmpty(from))
                                        return Redirect(HttpUtility.UrlDecode(from));
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
                            ViewBag.Msg = "服务器异常，请稍后重试";
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

        #endregion

        #region 功能相关
        
        [AuthFilter]
        public ViewResult List(int pageIndex = 1)
        {
            var schoolId = ApplicationContext.SchoolId;
            var args = new GetUserInfoByPagingArgs()
            {
                PageSize = 10,
                SchoolId = schoolId,
                PageIndex = pageIndex,
                WhereStr = "",
                OrderBy = ""
            };
            var result = UserService.Instance.GetUserInfoByPaging(args);
            ViewBag.PageCount = args.RowsCount / args.PageSize + 1;
            ViewBag.PageSize = args.PageSize;
            ViewBag.PageIndex = args.PageIndex;

            return View(result.Items);
        }

        [AuthFilter]
        public ViewResult Password()
        {
            SetToken();
            return View();
        }

        [HttpPut]
        [AuthFilter]
        public string ChangePassword(PasswordInfo passwordInfo)
        {
            try
            {
                var userId = ApplicationContext.UserId;
                var schoolId = ApplicationContext.SchoolId;
                if (passwordInfo != null && Request.Cookies.AllKeys.Contains("TOKEN"))
                {
                    var key = Request.Cookies["TOKEN"];
                    var iv = Request.Cookies["IV"];
                    if (key != null && iv != null)
                    {
                        //先解密码，然后比对系统中的密码
                        var originalPassword = DesEncryptHelper.Decrypt3Des(passwordInfo.OriginalPassword, key.Value,
                            CipherMode.CBC,
                            iv.Value);
                        var newPassword = DesEncryptHelper.Decrypt3Des(passwordInfo.NewPassword, key.Value,
                            CipherMode.CBC,
                            iv.Value);

                        var userInfo = UserService.Instance.GetUserInfoByUserId(new GetObjectByIdArgs()
                        {
                            Id = userId,
                            SchoolId = schoolId
                        });

                        if (userInfo.Code == 200)
                        {
                            var user = userInfo.Items.FirstOrDefault();
                            if (user != null)
                            {
                                //通过用户的token解密用户密码，然后跟此次输入密码比对
                                var userToken = user.Token.Substring(0, 24);
                                var userIv = user.Token.Substring(24, 8);
                                var userPassword = DesEncryptHelper.Decrypt3Des(user.Password, userToken,
                                    CipherMode.ECB,
                                    userIv);
                                //对比原始密码
                                if (userPassword == originalPassword)
                                {
                                    //开始修改密码
                                    var newPasswordEncrypt = DesEncryptHelper.Encrypt3Des(newPassword, userToken,
                                        CipherMode.ECB, userIv);
                                    var result = UserService.Instance.UpdateUserPassword(new UpdatePasswordArgs()
                                    {
                                        ModifyBy = userId,
                                        SchoolId = schoolId,
                                        Password = newPasswordEncrypt,
                                        UserId = userId
                                    });
                                    return JsonHelper.Serialize(result);
                                }
                                return JsonHelper.Serialize(CommandResult.Failure("原始密码错误"));
                            }
                            return JsonHelper.Serialize(CommandResult.Failure("用户不存在"));
                        }
                        return JsonHelper.Serialize(CommandResult.Failure("服务器异常，请稍后重试"));
                    }
                }
                return JsonHelper.Serialize(CommandResult.Failure("页面数据异常，请刷新页面"));
            }
            catch (Exception e)
            {
                return JsonHelper.Serialize(CommandResult.Failure("服务器异常：" + e.ToString()));
            }
        }

        [AuthFilter]
        public ViewResult Update()
        {
            var userId = ApplicationContext.UserId;
            var schoolId = ApplicationContext.SchoolId;
            var userInfoResult = UserService.Instance.GetUserInfoByUserId(new GetObjectByIdArgs()
            {
                Id = userId,
                SchoolId = ApplicationContext.SchoolId
            });
            var userInfo = new UserLite();
            if (userInfoResult.Code == 200)
            {
                userInfo = userInfoResult.Items.FirstOrDefault();
            }

            return View(userInfo);
        }

        [HttpPut]
        [AuthFilter]
        public string UpdateUser(UpdateUserArgs args)
        {
            var userId = ApplicationContext.UserId;
            var schoolId = ApplicationContext.SchoolId;
            if (args != null)
            {
                args.UserId = userId;
                args.SchoolId = schoolId;
                args.ModifyBy = userId;
                var result = UserService.Instance.UpdateUserInfo(args);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure());
        }

        [HttpDelete]
        [AuthFilter]
        public string Delete(int userId)
        {
            var args = new DeleteUserArgs()
            {
                UserId = userId,
                ModifyBy = ApplicationContext.UserId,
                SchoolId = ApplicationContext.SchoolId
            };
            var result = UserService.Instance.DeleteUser(args);
            return JsonHelper.Serialize(result);
        }

        [HttpPut]
        [AuthFilter]
        public string UpdateUserRole(UpdateUserRoleArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;
                var result = UserService.Instance.UpdateUserRole(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure("数据格式错误"));
        }

        #endregion


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
