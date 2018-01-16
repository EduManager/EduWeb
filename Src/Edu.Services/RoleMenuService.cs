using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beisen.CSTinsight.Repository;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Bussiness;
using Edu.Model.Procedure;

namespace Edu.Services
{
    public class RoleMenuService
    {
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        QueryResult<RoleMenuItem> GetRoleMenuByRoleId(int roleId)
        {
            Arguments.Positive(roleId, "roleId");

            return ContainerFactory<IRoleMenuRepository>.Instance.GetRoleMenuByRoleId(new GetRoleMenuByRoleIdArgs()
            {
                RoleId = roleId
            });
        }
    }
}
