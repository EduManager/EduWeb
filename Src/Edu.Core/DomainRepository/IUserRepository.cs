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
    public interface IUserRepository
    {
        /// <summary>
        /// 通过登录账号获取用户信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<User> GetUserInfoByLoginInAccount(LoginInArgs args);
        
    }
}
