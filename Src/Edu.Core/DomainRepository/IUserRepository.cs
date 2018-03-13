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
    public interface IUserRepository : IRepository
    {
        /// <summary>
        /// 通过登录账号获取用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<UserForLogin> GetUserInfoByLoginInAccount(LoginInArgs args);

        /// <summary>
        /// 通过userid获取用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<UserLite> GetUserInfoByUserId(GetObjectByIdArgs args);

        /// <summary>
        /// 分页获取用户信息
        /// </summary>
        /// <returns></returns>
        QueryResult<User> GetUserInfoByPaging(GetUserInfoByPagingArgs args);

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateUserInfo(UpdateUserArgs args);

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateUserPassword(UpdatePasswordArgs args);

        /// <summary>
        /// 添加用户登陆日志
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<object> AddUserLoginLog(AddUserLoginLogArgs args);

        /// <summary>
        /// 创建或编辑用户角色
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<object> CreateOrUpdateUserRole(CreateOrUpdateUserRoleArgs args);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> DeleteUser(DeleteUserArgs args);

        /// <summary>
        /// 管理员身份修改用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateUserByAdmin(UpdateUserByAdminArgs args);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<object> AddUser(AddUserArgs args);
    }
}
