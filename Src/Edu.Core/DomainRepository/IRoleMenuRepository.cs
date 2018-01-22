using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Core.DomainRepository
{
    public interface IRoleMenuRepository
    {
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<RoleMenuItem> GetRoleMenuByRoleId(GetRoleMenuByRoleIdArgs args);

        /// <summary>
        /// 通过角色清除角色权限（需要重设置）
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> ClearRoleMenuByRoleId(ClearRoleMenuByRoleIdArgs args);

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<object> AddRoleMenu(AddRoleMenuArgs args);
    }
}
