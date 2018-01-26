using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Edu.Controller.Common;

namespace Edu.Controller.Controller
{
    [AuthFilter]
    public class HomeController : System.Web.Mvc.Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Contract()
        {
            return View();
        }
    }
}
