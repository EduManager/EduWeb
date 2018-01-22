using System;
using System.Collections.Generic;
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
    internal class RoleRepository : IRoleRepository
    {
        public QueryResult<Role> GetRoleBySchoolId(GetRoleBySchoolIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Role>("get_role_by_school_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过学校ID获取角色列表败", e);
                return QueryResult.Failure<Role>();
            }
        }

        public CommandResult<int> AddRole(AddRoleArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>("add_role", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "创建角色失败，SchoolId:" + args.SchoolId + ",角色名称:" + args.Name, e);
                return CommandResult.Failure<int>();
            }
        }

        public CommandResult<int> DeleteRole(DeleteRoleArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure("delete_role", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "删除角色失败，RoleId:" + args.RoleId , e);
                return CommandResult.Failure<int>();
            }
        }

        public CommandResult<int> UpdateRole(UpdateRoleArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure("add_role_menu", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "编辑角色失败，RoleId:" + args.RoleId, e);
                return CommandResult.Failure<int>();
            }
        }
    }
}
