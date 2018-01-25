using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var token = Guid.NewGuid().ToString().Replace("-", "").Substring(0,24);
            var timespan = DateTime.Now.ToLongTime().ToString().Substring(0,8);
            ViewBag.Token = token + timespan;
            HttpCookie tokenCookie = new HttpCookie("Token",token);
            Response.Cookies.Add(tokenCookie);
            return View();
        }

        [HttpPost]
        public string SignIn(string parameters)
        {
            try
            {
                if (Request.Cookies.AllKeys.Contains("Token"))
                {
                    var token = Request.Cookies["Token"];
                    var loginInfo = JsonHelper.Deserialize<LoginUserInfo>(parameters);
                    if (loginInfo != null)
                    {

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
