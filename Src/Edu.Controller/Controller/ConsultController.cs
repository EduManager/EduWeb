using System;
using System.Collections.Generic;
using System.IO;
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
    [AuthFilter]
    public class ConsultController : System.Web.Mvc.Controller
    {

        public ViewResult ConsultList()
        {
            ViewData["StartNumber"] = 1;
            return View();
        }
        
    }
}
