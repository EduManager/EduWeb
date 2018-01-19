using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Core.Procedure;
using Edu.Model;
using Edu.Model.Core;

namespace Edu.Repository
{
    internal class RoleMenuRepository : IRoleMenuRepository
    {
        public QueryResult<RoleMenuItem> GetRoleMenuByRoleId(GetRoleMenuByRoleIdArgs args)
        {
            var result = ContainerFactory<ISqlExcuteContext>.Instance.RunProcedure<RoleMenuItem>("get_role_menu_by_role_id", args);
            return result;
        }
    }
}
