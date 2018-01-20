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
    public class RoleService
    {
        #region Singletonton

        private static RoleService _instance = new RoleService();

        private RoleService()
        {

        }

        public static RoleService Instance => _instance ?? (_instance = new RoleService());

        #endregion

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Role> GetRoleBySchoolId(GetRoleBySchoolIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<IRoleRepository>.Instance.GetRoleBySchoolId(args);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult AddRole(AddRoleArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            ArgumentHelper.Require(args.Name, "Name", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IRoleRepository>.Instance.AddRole(args);
        }
    }
}
