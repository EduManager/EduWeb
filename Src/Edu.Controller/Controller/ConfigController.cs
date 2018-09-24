using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Edu.Controller.Common;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Services;

namespace Edu.Controller.Controller
{
    [AuthFilter]
    public class ConfigController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            var schoolInfo = SysConfigService.Instance.GetSchoolInfoById(new GetObjectByIdArgs()
            {
                SchoolId = ApplicationContext.SchoolId
            });

            if (schoolInfo.Code == 200)
            {
                return View(schoolInfo.Items.FirstOrDefault());
            }
            return View();
        }

        [HttpPost]
        [Route("v1/school/logo_img")]
        public string PictureUpload(string data)
        {
            var index = data.IndexOf("base");
            var imgData = data.Substring(index + 7);

            //保存数据
            var tmpDir = Server.MapPath("~/Content/logo/");
            var schoolId = ApplicationContext.SchoolId;
            var dir = tmpDir + schoolId;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            byte[] arrB = Convert.FromBase64String(imgData);
            MemoryStream ms = new MemoryStream(arrB);
            Bitmap bmp = new Bitmap(ms);
            var filename = Guid.NewGuid() + ".png";
            var newfile = dir + "\\" + filename;
            bmp.Save(newfile, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();

            var imgPath = schoolId +"\\"+ filename;

            var args = new UpdateSchoolImgArgs()
            {
                ImgPath = imgPath,
                SchoolId = ApplicationContext.SchoolId
            };
            var result = SysConfigService.Instance.UpdateSchoolImg(args);
            var dataResult = JsonHelper.Serialize(result);
            return dataResult;
        }
    }
}
