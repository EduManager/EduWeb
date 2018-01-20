using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
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
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<RoleMenuItem> GetRoleMenuByRoleId(GetRoleMenuByRoleIdArgs args)
        {
            ArgumentHelper.Require(args.RoleId, "RoleId",Arguments.Positive);

            return ContainerFactory<IRoleMenuRepository>.Instance.GetRoleMenuByRoleId(args);
        }


        /// <summary>
        /// 通过角色清除角色权限（需要重设置）
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult ClearRoleMenuByRoleId(ClearRoleMenuByRoleIdArgs args)
        {
            ArgumentHelper.Require(args.RoleId, "RoleId", Arguments.Positive);

            return ContainerFactory<IRoleMenuRepository>.Instance.ClearRoleMenuByRoleId(args);
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult AddRoleMenu(AddRoleMenuArgs args)
        {
            ArgumentHelper.Require(args.RoleId, "RoleId", Arguments.Positive);
            ArgumentHelper.Require(args.MenuId, "MenuId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IRoleMenuRepository>.Instance.AddRoleMenu(args);
        }
    }
}
