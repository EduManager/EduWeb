using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Repository
{
    internal class RoleMenuRepository : IRoleMenuRepository
    {
        public QueryResult<RoleMenuItem> GetRoleMenuByRoleId(GetRoleMenuByRoleIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<RoleMenuItem>(
                        "get_role_menu_by_role_id", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过角色ID获取角色权限列表失败", e);
                return QueryResult.Failure<RoleMenuItem>();
            }
        }

        public CommandResult<int> ClearRoleMenuByRoleId(ClearRoleMenuByRoleIdArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure("clear_role_menu_by_role_id",
                    args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过角色ID清除角色权限信息失败", e);
                return CommandResult.Failure<int>();
            }
        }

        public CommandResult<object> AddRoleMenu(AddRoleMenuArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteScalarProceDure("add_role_menu",
                    args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "新增角色权限信息失败", e);
                return CommandResult.Failure<object>();
            }
        }
    }
}
