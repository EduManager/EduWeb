using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beisen.CSTinsight.Repository;
using Edu.Core.DomainRepository;
using Edu.Model;
using Edu.Model.Bussiness;
using Edu.Model.Core;
using Edu.Model.Procedure;

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
