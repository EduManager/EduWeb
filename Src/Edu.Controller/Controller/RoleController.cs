using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Edu.Controller.Model;
using Edu.Model.Core;
using Edu.Services;

namespace Edu.Controller.Controller
{
    public class RoleController : System.Web.Mvc.Controller
    {
        public ViewResult List()
        {
            var schoolId = 1;
            var result = RoleService.Instance.GetRoleBySchoolId(schoolId);
            var roles = new List<Role>();
            if (result.Code == 200)
                roles = result.Items;
            return View(roles);
        }

        [HttpGet]
        public JsonResult GetMenuList(int roleId)
        {
            List<TreeNode> result = new List<TreeNode>();
            //获取菜单
            var menuResult = MenuService.Instance.GetMenu();
            //获取角色对应的菜单
            var roleMenuResult = RoleMenuService.Instance.GetRoleMenuByRoleId(roleId);
            if (menuResult.Code == 200 && roleMenuResult.Code == 200)
            {
                var menus = menuResult.Items;
                var roleMenus = roleMenuResult.Items;
                foreach (var menu in menus)
                {
                    //如果包括子节点，则把该节点设置为checked：true
                    bool isCheck = roleMenus.Count>0 && roleMenus.Select(p => p.MenuId).Contains(menu.Id);
                    result.Add(new TreeNode
                    {
                        Id = menu.Id,
                        PId = menu.ParentId,
                        Name = menu.Name,
                        Checked = isCheck
                    });
                }
            }
            //如果子节点被选中，父节点也要被选中
            foreach (var item in result)
            {
                if (item.PId != 0 && item.Checked)
                {
                    var parentItem = result.FirstOrDefault(p => p.Id == item.PId);
                    if (parentItem != null) parentItem.Checked = item.Checked;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
