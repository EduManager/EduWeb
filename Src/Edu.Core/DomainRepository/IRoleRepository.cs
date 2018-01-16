using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Model;
using Edu.Model.Bussiness;
using Edu.Model.Core;
using Edu.Model.Procedure;

namespace Edu.Core.DomainRepository
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<Role> GetRoleBySchoolId(GetRoleBySchoolIdArgs args);
    }
}
