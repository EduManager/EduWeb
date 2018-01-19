using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Core.Procedure;
using Edu.Model;
using Edu.Model.Core;

namespace Edu.Repository
{
    internal class RoleRepository : IRoleRepository
    {
        public QueryResult<Role> GetRoleBySchoolId(GetRoleBySchoolIdArgs args)
        {
            var result = ContainerFactory<ISqlExcuteContext>.Instance.RunProcedure<Role>("get_role_by_school_id", args);
            return result;
        }
    }
}
