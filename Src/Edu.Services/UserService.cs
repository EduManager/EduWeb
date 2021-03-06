﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Repository;

namespace Edu.Services
{
    public class UserService
    {
        #region Singletonton

        private static UserService _instance = new UserService();

        private UserService()
        {

        }

        public static UserService Instance => _instance ?? (_instance = new UserService());

        #endregion

        /// <summary>
        /// 通过登录账号获取用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<UserForLogin> GetUserInfoByLoginInAccount(LoginInArgs args)
        {
            ArgumentHelper.Require(args.Account, "RoleId",Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IUserRepository>.Instance.GetUserInfoByLoginInAccount(args);
        }

        /// <summary>
        /// 通过userid获取用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<UserLite> GetUserInfoByUserId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.OId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<IUserRepository>.Instance.GetUserInfoByUserId(args);
        }

        /// <summary>
        /// 分页获取用户信息
        /// </summary>
        /// <returns></returns>
        public QueryResult<User> GetUserInfoByPaging(GetObjectsByPagingArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.PageSize, "PageSize", Arguments.Positive);
            ArgumentHelper.Require(args.PageIndex, "PageIndex", Arguments.Positive);

            return ContainerFactory<IUserRepository>.Instance.GetUserInfoByPaging(args);
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateUserInfo(UpdateUserArgs args)
        {
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            ArgumentHelper.Require(args.Email, "Email", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Phone, "Phone", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IUserRepository>.Instance.UpdateUserInfo(args);
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateUserPassword(UpdatePasswordArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            ArgumentHelper.Require(args.Password, "Password", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IUserRepository>.Instance.UpdateUserPassword(args);
        }

        /// <summary>
        /// 添加用户登陆日志
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<object> AddUserLoginLog(AddUserLoginLogArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.LoginIp, "LoginIp", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IUserRepository>.Instance.AddUserLoginLog(args);
        }

        /// <summary>
        /// 编辑用户角色
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<object> CreateOrUpdateUserRole(CreateOrUpdateUserRoleArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.RoleId, "RoleId", Arguments.Positive);
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IUserRepository>.Instance.CreateOrUpdateUserRole(args);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> DeleteUser(DeleteObjectArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.ObjectId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IUserRepository>.Instance.DeleteUser(args);
        }

        /// <summary>
        /// 管理员身份修改用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateUserByAdmin(UpdateUserByAdminArgs args)
        {
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.RegionId, "RegionId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            ArgumentHelper.Require(args.Email, "Email", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Name, "Name", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Phone, "Phone", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IUserRepository>.Instance.UpdateUserByAdmin(args);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<object> AddUser(AddUserArgs args)
        {
            ArgumentHelper.Require(args.RoleId, "RoleId", Arguments.Positive);
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.RegionId, "RegionId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.Email, "Email", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Name, "Name", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Phone, "Phone", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IUserRepository>.Instance.AddUser(args);
        }

        /// <summary>
        /// 从Excel导入用户
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="userId"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public CommandResult ImportUsersByExcel(int schoolId, int userId, string filePath)
        {
            ArgumentHelper.Require(schoolId, "schoolId", Arguments.Positive);
            ArgumentHelper.Require(userId, "userId", Arguments.Positive);
            if (File.Exists(filePath))
            {
                FileInfo fi = new FileInfo(filePath);
                if (fi.Extension == ".xls" || fi.Extension == ".xlsx")
                {
                    return ContainerFactory<IUserRepository>.Instance.ImportUsersByExcel(schoolId, userId,filePath);
                }
                else
                {
                    LogHelper.Info(typeof(UserService), "文件类型不匹配,文件名:" + filePath);
                }
            }
            else
            {
                LogHelper.Info(typeof(UserService), "文件不存在,文件名:" + filePath);
            }
            return CommandResult.Failure();
        }
    }
}
