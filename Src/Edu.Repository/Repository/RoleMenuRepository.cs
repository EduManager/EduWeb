using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Repository
{
    internal class RoleMenuRepository : IRoleMenuRepository
    {
        public QueryResult<RoleMenuItem> GetRoleMenuByRoleId(GetRoleMenuByRoleIdArgs args)
        {
            var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<RoleMenuItem>("get_role_menu_by_role_id", args);
            return result;
        }

        public CommandResult ClearRoleMenuByRoleId(ClearRoleMenuByRoleIdArgs args)
        {
            var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure("clear_role_menu_by_role_id",
                args);
            return result;
        }

        public CommandResult AddRoleMenu(AddRoleMenuArgs args)
        {
            var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteScalarProceDure("add_role_menu",
                   args);
            return result;
        }
    }
}
