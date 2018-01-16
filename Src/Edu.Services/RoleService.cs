using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beisen.CSTinsight.Repository;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Bussiness;
using Edu.Model.Core;
using Edu.Model.Procedure;

namespace Edu.Services
{
    public class RoleService
    {
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        QueryResult<Role> GetRoleBySchoolId(int schoolId)
        {
            Arguments.Positive(schoolId, "schoolId");

            return ContainerFactory<IRoleRepository>.Instance.GetRoleBySchoolId(new GetRoleBySchoolIdArgs()
            {
                SchoolId = schoolId
            });
        }
    }
}
