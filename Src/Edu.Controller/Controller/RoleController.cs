using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
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
    public class RoleController : System.Web.Mvc.Controller
    {
        public ViewResult List()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = RoleService.Instance.GetRoleBySchoolId(new GetObjectByIdArgs()
            {
                Id = schoolId
            });
            var roles = new List<Role>();
            if (result.Code == 200)
                roles = result.Items;
            return View(roles);
        }

        [HttpGet]
        [ActionName("SchoolRoles")]
        public string Roles()
        {
            var schoolId = ApplicationContext.SchoolId;
            var result = RoleService.Instance.GetRoleBySchoolId(new GetObjectByIdArgs()
            {
                Id = schoolId
            });
            return JsonHelper.Serialize(result);
        }
        
        [HttpDelete]
        public string Delete(int roleId)
        {
            var result = RoleService.Instance.DeleteRole(new DeleteRoleArgs()
            {
                SchoolId = ApplicationContext.SchoolId,
                RoleId = roleId,
                ModifyBy = ApplicationContext.UserId
            });
            return JsonHelper.Serialize(result);
        }

        [HttpPut]
        public string Update(UpdateRoleArgs model)
        {
            if (model != null)
            {
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;
                var result = RoleService.Instance.UpdateRole(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpPost]
        public string Add(AddRoleArgs model)
        {
            if (model != null)
            {
                model.CreateBy = ApplicationContext.UserId;
                model.ModifyBy = ApplicationContext.UserId;
                model.SchoolId = ApplicationContext.SchoolId;

                var result = RoleService.Instance.AddRole(model);
                return JsonHelper.Serialize(result);
            }
            return JsonHelper.Serialize(CommandResult.Failure<int>());
        }

        [HttpPost]
        public string Commit(int roleId,string parametes)
        {
            var nodes = JsonHelper.Deserialize<List<TreeNode>>(parametes);
            if (nodes != null)
            {
                //先清除原有角色权限
                RoleMenuService.Instance.ClearRoleMenuByRoleId(new ClearRoleMenuByRoleIdArgs()
                {
                    RoleId = roleId,
                    SchoolId = ApplicationContext.SchoolId,
                    ModifyBy = ApplicationContext.UserId
                });
                var selectNodes = nodes.Where(p => p.Checked);
                var rowCount = 0;
                //依次添加权限
                foreach (var selectNode in selectNodes)
                {
                    RoleMenuService.Instance.AddRoleMenu(new AddRoleMenuArgs()
                    {
                        SchoolId = ApplicationContext.SchoolId,
                        RoleId = roleId,
                        CreateBy = ApplicationContext.UserId,
                        ModifyBy = ApplicationContext.UserId,
                        MenuId = selectNode.Id
                    });
                    rowCount++;
                }
                return JsonHelper.Serialize(CommandResult.Success(rowCount));
            }
            return JsonHelper.Serialize(CommandResult.Failure());
        }

        [HttpGet]
        public string GetList(int roleId)
        {
            List<TreeNode> result = new List<TreeNode>();
            //获取菜单
            var menuResult = MenuService.Instance.GetMenu();
            //获取角色对应的菜单
            var roleMenuResult = RoleMenuService.Instance.GetRoleMenuByRoleId(new GetObjectByIdArgs()
            {
                Id = roleId,
                SchoolId = ApplicationContext.SchoolId
            });
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
            return JsonHelper.Serialize(QueryResult.Success(result));
        }
    }
}
