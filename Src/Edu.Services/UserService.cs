﻿using System;
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
        public QueryResult<User> GetUserInfoByLoginInAccount(LoginInArgs args)
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
            ArgumentHelper.Require(args.Id, "UserId", Arguments.Positive);

            return ContainerFactory<IUserRepository>.Instance.GetUserInfoByUserId(args);
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateUserInfo(UpdateUserArgs args)
        {
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
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
            ArgumentHelper.Require(args.UserId, "UserId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);
            ArgumentHelper.Require(args.Password, "Password", Arguments.NotEmptyOrWhitespace);

            return ContainerFactory<IUserRepository>.Instance.UpdateUserPassword(args);
        }
    }
}
