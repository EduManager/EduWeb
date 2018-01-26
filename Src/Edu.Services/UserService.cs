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
        
    }
}
