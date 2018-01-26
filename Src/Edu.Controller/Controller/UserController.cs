using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Edu.Controller.Model;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;

namespace Edu.Controller.Controller
{
    public class UserController : System.Web.Mvc.Controller
    {
        public ViewResult Login()
        {
            var timespan = DateTime.Now.ToLongTime().ToString();
            var token = Guid.NewGuid().ToString().Replace("-", "");
            var key = token.Substring(0, 24);
            var iv = timespan.Substring(2, 8);
            ViewBag.Secret = key;
            ViewBag.IV = iv;
            HttpCookie tokenCookie = new HttpCookie("TOKEN", key);
            HttpCookie keyCookie = new HttpCookie("IV", iv);
            Response.Cookies.Add(tokenCookie);
            Response.Cookies.Add(keyCookie);
            return View();
        }

        [HttpPost]
        public string SignIn(string parameters)
        {
            try
            {
                if (Request.Cookies.AllKeys.Contains("TOKEN"))
                {
                    var key = Request.Cookies["TOKEN"];
                    var iv = Request.Cookies["IV"];
                    var loginInfo = JsonHelper.Deserialize<LoginUserInfo>(parameters);
                    if (loginInfo != null && key != null && iv != null)
                    {
                        var account = DesEncryptHelper.Decrypt3Des(loginInfo.Account, key.Value, CipherMode.CBC,
                            iv.Value);
                        var password = DesEncryptHelper.Decrypt3Des(loginInfo.Password, key.Value, CipherMode.CBC,
                            iv.Value);

                    }
                }
                return JsonHelper.Serialize(CommandResult.Failure("令牌格式错误！"));
            }
            catch (Exception e)
            {
                return JsonHelper.Serialize(CommandResult.Failure(e.ToString()));
            }
        }
    }
}
