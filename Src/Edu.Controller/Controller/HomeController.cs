using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Edu.Controller.Controller
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
