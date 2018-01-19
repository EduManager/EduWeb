using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Core.Procedure;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Core;
using Edu.Repository;

namespace Edu.Services
{
    public class RoleService
    {
        #region Singletonton

        private static RoleService _instance = new RoleService();

        private RoleService()
        {

        }

        public static RoleService Instance => _instance ?? (_instance = new RoleService());

        #endregion

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public QueryResult<Role> GetRoleBySchoolId(int schoolId)
        {
            Arguments.Positive(schoolId, "schoolId");

            return ContainerFactory<IRoleRepository>.Instance.GetRoleBySchoolId(new GetRoleBySchoolIdArgs()
            {
                SchoolId = schoolId
            });
        }
    }
}
