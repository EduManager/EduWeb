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
    internal class UserRepository : BaseRepository, IUserRepository
    {
        public QueryResult<User> GetUserInfoByLoginInAccount(LoginInArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<User>(
                        "get_userinfo_by_account", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "登陆模块--通过角色邮箱或手机号获取角色权限列表失败", e);
                return QueryResult.Failure<User>(e.ToString());
            }
        }

        public QueryResult<UserLite> GetUserInfoByLoginInAccount(GetObjectByIdArgs args)
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
    }
}
