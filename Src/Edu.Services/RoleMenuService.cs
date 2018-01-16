using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Bussiness;
using Edu.Model.Procedure;
using Edu.Repository;

namespace Edu.Services
{
    public class RoleMenuService
    {
        #region Singletonton

        private static RoleMenuService _instance = new RoleMenuService();

        private RoleMenuService()
        {

        }

        public static RoleMenuService Instance => _instance ?? (_instance = new RoleMenuService());

        #endregion

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public QueryResult<RoleMenuItem> GetRoleMenuByRoleId(int roleId)
        {
            Arguments.Positive(roleId, "roleId");

            return ContainerFactory<IRoleMenuRepository>.Instance.GetRoleMenuByRoleId(new GetRoleMenuByRoleIdArgs()
            {
                RoleId = roleId
            });
        }
    }
}
