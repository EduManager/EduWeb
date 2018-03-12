using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Repository
{
    internal class RoleRepository : BaseRepository, IRoleRepository
    {
        public QueryResult<Role> GetRoleBySchoolId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Role>(0, "get_role_by_school_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "角色模块-通过学校ID获取角色列表败", e);
                return QueryResult.Failure<Role>(e.ToString());
            }
        }

        public CommandResult<object> AddRole(AddRoleArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteScalarProceDure(0, "add_role", args);
                
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "角色模块-创建角色失败，SchoolId:" + args.SchoolId + ",角色名称:" + args.Name, e);
                return CommandResult.Failure<object>(e.ToString());
            }
        }

        public CommandResult<int> DeleteRole(DeleteRoleArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "delete_role", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "角色模块-删除角色失败，RoleId:" + args.RoleId , e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> UpdateRole(UpdateRoleArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "update_role", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "角色模块-编辑角色失败，RoleId:" + args.RoleId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
    }
}
