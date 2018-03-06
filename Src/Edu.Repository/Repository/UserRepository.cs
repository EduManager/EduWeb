using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Infrastructure.Sql;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Repository
{
    internal class UserRepository : BaseRepository, IUserRepository
    {
        public QueryResult<UserForLogin> GetUserInfoByLoginInAccount(LoginInArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<UserForLogin>(
                        "get_userinfo_by_account", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户登陆模块--通过角色邮箱或手机号获取角色权限列表失败", e);
                return QueryResult.Failure<UserForLogin>(e.ToString());
            }
        }

        public QueryResult<UserLite> GetUserInfoByUserId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<UserLite>(
                        "get_userinfo_by_id", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户模块--通过角色ID获取角色权限列表失败", e);
                return QueryResult.Failure<UserLite>(e.ToString());
            }
        }

        public QueryResult<User> GetUserInfoByPaging(GetUserInfoByPagingArgs args)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@p_school_id",args.SchoolId);
                p.Add("@p_page_size", args.PageSize);
                p.Add("@p_page_now", args.PageIndex);
                p.Add("@p_order_string", args.OrderBy);
                p.Add("@p_where_string", args.WhereStr);
                p.Add("@p_out_rows", null, DbType.Int32, ParameterDirection.Output);
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<User>("get_users_by_paging", p);
                args.RowsCount = p.Get<int>("@p_out_rows");
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户模块--通过角色ID获取角色权限列表失败", e);
                return QueryResult.Failure<User>(e.ToString());
            }
        }

        public CommandResult<int> UpdateUserInfo(UpdateUserArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure("update_userinfo", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户模块--通过角色ID获取角色权限列表失败", e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> UpdateUserPassword(UpdatePasswordArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure("update_userinfo_password", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户模块--修改密码失败", e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<object> AddUserLoginLog(AddUserLoginLogArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteScalarProceDure("add_user_log", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户模块--添加用户登陆日志失败", e);
                return CommandResult.Failure<object>(e.ToString());
            }
        }

        public CommandResult<object> UpdateUserRole(UpdateUserRoleArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteScalarProceDure("create_or_update_userrole",
                    args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户模块-编辑用户角色信息失败", e);
                return CommandResult.Failure<object>(e.ToString());
            }
        }

        public CommandResult<int> DeleteUser(DeleteUserArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure("delete_user", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "用户模块-删除用户失败，UserId:" + args.UserId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
    }
}
